from __future__ import annotations
from typing import List, Optional, Set, Dict

# === Note system (12-TET pitch classes) =====================================

NAME_TO_PC = {
    # Naturals
    "C": 0, "D": 2, "E": 4, "F": 5, "G": 7, "A": 9, "B": 11,
    # Sharps
    "C#": 1, "D#": 3, "F#": 6, "G#": 8, "A#": 10,
    # Flats (enharmonic)
    "Db": 1, "Eb": 3, "Gb": 6, "Ab": 8, "Bb": 10,
    # Enharmonic edge cases
    "B#": 0, "E#": 5, "Cb": 11, "Fb": 4,
}

# Default: prefer sharps for display. You can switch to flats with this map.
PC_TO_NAME_SHARP = {
    0: "C",  1: "C#", 2: "D",  3: "D#", 4: "E",  5: "F",
    6: "F#", 7: "G",  8: "G#", 9: "A", 10: "A#", 11: "B",
}
PC_TO_NAME_FLAT = {
    0: "C",  1: "Db", 2: "D",  3: "Eb", 4: "E",  5: "F",
    6: "Gb", 7: "G",  8: "Ab", 9: "A", 10: "Bb", 11: "B",
}

def pc_name(pc: int, prefer_sharps: bool = True) -> str:
    return (PC_TO_NAME_SHARP if prefer_sharps else PC_TO_NAME_FLAT)[pc % 12]

# Given a root PC and a sequence of intervals, produce a set of pitch classes
def scale_pcs(root_name: str, intervals: List[int]) -> Set[int]:
    if root_name not in NAME_TO_PC:
        raise ValueError(f"Unknown root note: {root_name}")
    root = NAME_TO_PC[root_name]
    return {(root + i) % 12 for i in intervals}

# Some handy interval patterns (in semitones) for common scales
SCALE_PATTERNS: Dict[str, List[int]] = {
    "major":        [0, 2, 4, 5, 7, 9, 11],
    "natural_minor":[0, 2, 3, 5, 7, 8, 10],
    "dorian":       [0, 2, 3, 5, 7, 9, 10],
    "mixolydian":   [0, 2, 4, 5, 7, 9, 10],
    "minor_pent":   [0, 3, 5, 7, 10],
    "major_pent":   [0, 2, 4, 7, 9],
}

# === Fingerboard generator ===================================================

def render_fretboard(
    tuning: List[str] = ["E", "A", "D", "G", "B", "E"],  # low→high (standard)
    num_frets: int = 12,
    prefer_sharps: bool = True,
    show_note_names: bool = True,
    show_all_notes: bool = True,  # if False and a scale is provided, hide non-scale notes
    scale_root: Optional[str] = None,
    scale_name: Optional[str] = None,  # e.g., "major", "minor_pent"
    highlight_root: bool = True,  # if scale_root provided, emphasize root
    string_labels: Optional[List[str]] = None,  # custom labels for left margin
    fret_markers: Optional[Set[int]] = None,    # e.g., {3,5,7,9,12}
    col_width: int = 3,  # cell width per fret (3 works nicely)
) -> str:
    """
    Returns an ASCII representation of a guitar fretboard.

    - Strings run horizontally. Fret 0 (open) at the left; higher frets to the right.
    - 'tuning' is low→high (6→1). Use 4 or 7 strings by changing the list.
    - If a scale is set via (scale_root, scale_name), you can choose to show
      only those notes (show_all_notes=False), and optionally emphasize the root.
    """
    if num_frets < 0:
        raise ValueError("num_frets must be >= 0")
    if any(t not in NAME_TO_PC for t in tuning):
        raise ValueError("All tuning notes must be valid names (e.g., 'E', 'F#', 'Bb').")

    # Compute scale pitch classes if requested
    scale_pcset: Optional[Set[int]] = None
    root_pc: Optional[int] = None
    if scale_root and scale_name:
        if scale_name not in SCALE_PATTERNS:
            raise ValueError(f"Unknown scale '{scale_name}'. Known: {sorted(SCALE_PATTERNS.keys())}")
        scale_pcset = scale_pcs(scale_root, SCALE_PATTERNS[scale_name])
        root_pc = NAME_TO_PC[scale_root]

    # Fret marker defaults
    if fret_markers is None:
        # Typical inlays: 3,5,7,9,12 (12 is often double-dot)
        fret_markers = {3, 5, 7, 9, 12}

    # Prepare header line for fret numbers
    # Each fret column is fixed width; align numbers roughly center.
    def center_in(width: int, text: str) -> str:
        if len(text) >= width:
            return text[:width]
        pad = width - len(text)
        left = pad // 2
        right = pad - left
        return " " * left + text + " " * right

    # Build top header with fret numbers
    header = "     "  # left margin for string labels and nut
    header += center_in(col_width, "0")
    for f in range(1, num_frets + 1):
        header += " " + center_in(col_width, str(f))
    lines = [header]

    # Build each string row (top printed is the highest string by convention)
    # But many diagrams show high E at top; our tuning is low->high, so we reverse for display.
    display_strings = list(reversed(tuning))

    # Left label for each string: either custom or computed (e.g., "E", "A", etc.)
    if string_labels is None:
        # If two Es, mark the top one as e' for clarity
        # Generate labels from display_strings (which is high->low now)
        labels = []
        seen_e = 0
        for name in display_strings:
            if name.upper() == "E":
                seen_e += 1
                labels.append("e'" if seen_e == 1 else "E ")
            else:
                labels.append(name.ljust(2))
    else:
        labels = [lbl.ljust(2) for lbl in string_labels]
        if len(labels) != len(display_strings):
            raise ValueError("string_labels length must match the number of strings to display.")

    # Compose each string line
    for s_idx, open_name in enumerate(display_strings):
        open_pc = NAME_TO_PC[open_name]
        # Left label and nut
        row = f"{labels[s_idx]} |"
        # Fret 0 cell
        note_pc = open_pc
        cell = pc_name(note_pc, prefer_sharps) if show_note_names else ""
        symbol = cell
        # Apply scale filtering/marking
        if scale_pcset is not None:
            if note_pc not in scale_pcset and not show_all_notes:
                symbol = ""  # hide
            elif highlight_root and root_pc is not None and note_pc == root_pc:
                symbol = symbol.upper()  # emphasize root
        row += "-" + center_in(col_width, symbol).replace(" ", "-")

        # Frets 1..N
        for f in range(1, num_frets + 1):
            note_pc = (open_pc + f) % 12
            cell = pc_name(note_pc, prefer_sharps) if show_note_names else ""
            symbol = cell
            if scale_pcset is not None:
                if note_pc not in scale_pcset and not show_all_notes:
                    symbol = ""
                elif highlight_root and root_pc is not None and note_pc == root_pc:
                    symbol = symbol.upper()
            row += "-" + center_in(col_width, symbol).replace(" ", "-")
        row += "-|"
        lines.append(row)

    # Fret markers row (under strings)
    marker_row = "     " + " " * (col_width)  # under the '0' column there's usually no dot
    for f in range(1, num_frets + 1):
        mark = "^" if f in fret_markers else " "
        marker_row += " " + center_in(col_width, mark)
    lines.append(marker_row)

    # Fret marker numbers row (optional numeric hints under the markers)
    if fret_markers:
        num_row = "     " + " " * (col_width)
        for f in range(1, num_frets + 1):
            if f in fret_markers:
                txt = str(f)
            else:
                txt = ""
            num_row += " " + center_in(col_width, txt)
        lines.append(num_row)

    return "\n".join(lines)

# === Quick demo when run directly ===========================================
if __name__ == "__main__":
    print(render_fretboard())  # default
    print()
    # Example: Show only notes of C major; highlight C as root
    print(render_fretboard(scale_root="C", scale_name="major", show_all_notes=False))
