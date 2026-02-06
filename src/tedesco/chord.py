from __future__ import annotations

from dataclasses import dataclass
from typing import Dict, Iterator, List

from .interval import Interval

# ---------------------------------------------------------------------------
# Known chord patterns as cumulative semitone offsets from the root (0).
# This covers common triads, sevenths, and a few extensions. You can extend
# this dict at any time without changing the class.
# ---------------------------------------------------------------------------
KNOWN_CHORD_PATTERNS: Dict[str, str] = {
    # Triads
    "maj":     "0,4,7",
    "min":     "0,3,7",
    "dim":     "0,3,6",
    "aug":     "0,4,8",
    "sus2":    "0,2,7",
    "sus4":    "0,5,7",

    # Seventh chords
    "maj7":    "0,4,7,11",
    "dom7":    "0,4,7,10",     # a.k.a. 7
    "min7":    "0,3,7,10",     # a.k.a. m7
    "minmaj7": "0,3,7,11",     # m(maj7)
    "dim7":    "0,3,6,9",
    "m7b5":    "0,3,6,10",     # half-diminished (ø7)

    # 6/9 and extensions (rooted spellings; duplicates beyond octave are fine)
    "6":       "0,4,7,9",
    "m6":      "0,3,7,9",
    "add9":    "0,4,7,14",     # major triad + 9
    "madd9":   "0,3,7,14",
    "6/9":     "0,4,7,9,14",
    "m6/9":    "0,3,7,9,14",
    "maj9":    "0,4,7,11,14",
    "dom9":    "0,4,7,10,14",
    "min9":    "0,3,7,10,14",
    "maj11":   "0,4,7,11,14,17",
    "dom11":   "0,4,7,10,14,17",
    "min11":   "0,3,7,10,14,17",
    "maj13":   "0,4,7,11,14,17,21",
    "dom13":   "0,4,7,10,14,17,21",
    "min13":   "0,3,7,10,14,17,21",
}


def _parse_csv(csv: str) -> List[int]:
    if not isinstance(csv, str):
        raise TypeError("csv must be a comma-separated string of integers")
    out: List[int] = []
    for raw in csv.split(","):
        tok = raw.strip()
        if not tok:
            continue
        try:
            out.append(int(tok))
        except ValueError as exc:
            raise ValueError(f"Invalid integer in csv: {tok!r}") from exc
    if not out:
        raise ValueError("Empty interval list; provide at least '0' for the root")
    # Normalize: if root 0 is missing, prepend it
    if out[0] != 0:
        out = [0] + out
    return out


@dataclass(frozen=True)
class Chord:
    """
    A chord represented as a list of cumulative semitone intervals above the root.

    The class is intentionally simple—just a typed wrapper around List[Interval].
    Use `Chord("maj7")` or `Chord("0,4,7,11")`.
    """
    intervals: List[Interval]

    def __init__(self, value: str) -> "Chord":
        """
        Build a chord from either a known name or a CSV string of cumulative semitones.

        - If `value.lower()` matches a key in KNOWN_CHORD_PATTERNS, that pattern is used.
        - Otherwise, `value` is parsed as a CSV of cumulative semitone offsets.
        """
        name = value.strip().lower()
        if name in KNOWN_CHORD_PATTERNS:
            pattern = KNOWN_CHORD_PATTERNS[name]
        else:
            pattern = value
          
        degrees = _parse_csv(pattern)
        # For frozen dataclasses we must use object.__setattr__ in __init__
        object.__setattr__(self, "intervals", [Interval(n) for n in degrees])
      
    # ---- Basic container protocol ------------------------------------------
    def __iter__(self) -> Iterator[Interval]:
        return iter(self.intervals)

    def __len__(self) -> int:
        return len(self.intervals)

    def __contains__(self, item: Interval) -> bool:
        return item in self.intervals

    def to_notes(self, root_note) -> List:
        """
        Given a Note (from tedesco.note), return concrete notes for the chord.
        Lazy-imports Note to avoid circular import at module load time.
        """
        from .note import Note  # lazy import
        if not isinstance(root_note, Note):
            raise TypeError("root_note must be a tedesco.Note instance")
        return [root_note + iv for iv in self.intervals]
      
