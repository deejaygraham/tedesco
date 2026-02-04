# Map canonical scale names to *cumulative* semitone offsets above the root,
# expressed as comma-separated strings.
from __future__ import annotations

from dataclasses import dataclass
from typing import ClassVar, Dict, Iterable, Iterator, List, Optional

from .interval import Interval

SCALE_PATTERNS: dict[str, str] = {
    "eighttone_spanish":  "1,2,1,1,1,2,2,2",
    "aeolian":           "2,1,2,2,1,2,2",
    "algerian":          "2,1,2,1,1,1,3,1",
    "arabian":           "2,1,2,1,2,1,2,1",
    "augmented":         "3,1,3,1,3,1",
    "balinese":          "1,2,4,1,4",
    "bebop_dominant":     "2,2,1,2,2,1,1,1",
    "bebop_dorian":       "2,1,2,2,2,1,1,1",
    "bebop_major":        "2,2,1,2,1,1,2,1",
    "bebop_minor":        "2,1,2,2,1,1,1,2",
    "blues":             "3,2,1,1,3,2",
    "byzantine":         "1,3,1,2,1,3,1",
    "chinese":           "4,2,1,4,1",
    "chinese_mongolian":  "2,2,3,2,3",
    "chromatic":         "1,1,1,1,1,1,1,1,1,1",
    "diminished":        "2,1,2,1,2,1,2,1",
    "dominant":          "#2 3,1,1,2,2,1,2",
    "dominant_augmented": "2,2,1,3,1,1,2",
    "dominant_sus":       "2,3,2,2,1,2",
    "dorian":            "2,1,2,2,2,1,2",
    "double_harmonic":    "1,3,1,2,1,3,1",
    "egyptian":          "2,3,2,3,2",
    "enigmatic":         "1,3,2,2,2,1,1",
    "enigmatic_minor":    "1,2,3,1,3,1,1",
    "ethiopian_araray":   "2,2,1,2,2,2,1",
    "ethiopian_geez":     "2,1,2,2,1,2,2",
    "half_whole_diminished": "1,2,1,2,1,2,1,2",
    "harmonic_major":     "2,2,1,2,1,3,1",
    "harmonic_minor":     "2,1,2,2,1,3,1",
    "hawaiian":          "2,1,2,2,2,2,1",
    "hindu":             "2,2,1,2,1,2,2",
    "hindustan":         "2,2,1,2,1,2,2",
    "hirojoshi":         "2,1,4,1,4",
    "hungarian_gypsy":    "2,1,3,1,1,2,2",
    "hungarian_major":    "3,1,2,1,2,1,2",
    "hungarian_minor":    "2,1,3,1,1,3,1",
    "ionian":            "2,2,1,2,2,2,1",
    "japanese_a":         "1,4,2,1,4",
    "japanese_b":         "2,3,2,1,4",
    "japanese_ichikosucho": "2,2,1,1,1,2,2,1",
    "japanese_taishikicho": "2,2,1,1,1,2,1,1,1",
    "javaneese":         "1,2,2,2,2,1,2",
    "jewish_adonaimalakh": "1,1,1,2,2,2,1,2",
    "jewish_ahabarabba":  "1,3,1,2,1,2,2",
    "jewish_magenabot":   "1,2,1,2,2,2,1,1",
    "kumoi":             "2,1,4,2,3",
    "locrian":           "1,2,2,1,2,2,2",
    "lydian":            "2,2,2,1,2,2,1",
    "lydian_minor":       "2,2,2,1,1,2,2",
    "major":             "2,2,1,2,2,2,1",
    "major_locrian":      "2,2,1,1,2,2,2",
    "major_pentatonic":   "2,2,3,2,3",
    "melodic_augmented":  "2,1,2,3,1,2,1",
    "melodic_minor":      "2,1,2,2,2,2,1",
    "minor":             "2,1,2,2,1,2,2",
    "minor_pentatonic":   "3,2,2,3,2",
    "mixolydian":        "2,2,1,2,2,1,2",
    "natural_minor":      "2,1,2,2,1,2,2",
    "neapolitan_major":   "1,2,2,2,2,2,1",
    "neapolitan_minor":   "1,2,2,2,1,3,1",
    "oriental":          "1,3,1,1,3,1,2",
    "pelog":             "1,2,1,3,1,4",
    "pentatonic_major":   "2,2,3,2,3",
    "pentatonic_minor":   "3,2,2,3,2",
    "persian":           "1,3,1,1,2,3,1",
    "phrygian":          "1,2,2,2,1,2,2",
    "super_locrian":      "1,2,1,2,2,2,2",
    "super_lydian_augmented": "3,2,1,2,2,1,1",
    "theta_asavari":      "2,1,2,2,1,2,2",
    "theta_bhairav":      "1,3,1,2,1,3,1",
    "theta_bhairavi":     "1,2,2,2,1,2,2",
    "theta_bilaval":     "2,2,1,2,2,2,1",
    "theta_kafi":         "2,1,2,2,2,1,2",
    "theta_kalyan":       "2,2,2,1,2,2,1",
    "theta_khamaj":       "2,2,1,2,2,1,2",
    "theta_marva":        "1,3,2,1,2,2,1",
    "whole_half_diminished": "2,1,2,1,2,1,2,1",
    "wholetone":         "2,2,2,2,2,2"
}

ALIASES: dict[str, str] = {
    "ionian": "major",
    "aeolian": "natural_minor",
    "maj": "major",
    "min": "natural_minor",
    "maj_pent": "major_pentatonic",
    "min_pent": "minor_pentatonic",
}


def _resolve_name(name: str) -> str:
    key = name.strip().lower()
    return ALIASES.get(key, key)


@dataclass(frozen=True)
class Scale:
    """
    A musical scale defined by cumulative semitone offsets from the root.

    Examples
    --------
    Scale.from_steps("major", "2,2,1,2,2,2,1")  # builds cumulative: 0,2,4,5,7,9,11
    """
    name: str
    intervals: List[Interval]

    # ---- Registry (name -> Scale) ------------------------------------------
    registry: ClassVar[Dict[str, "Scale"]] = {}
    aliases: ClassVar[Dict[str, str]] = {}

    # ---- Basic dunder helpers ----------------------------------------------
    def __iter__(self) -> Iterator[Interval]:
        return iter(self.intervals)

    def __len__(self) -> int:
        return len(self.intervals)

    def __contains__(self, item: Interval) -> bool:
        return item in self.intervals

    def degrees(self) -> List[int]:
        """Return degree indices [1..N] for convenience; len == number of notes."""
        return list(range(1, len(self.intervals) + 1))

    # ---- Construction helpers ----------------------------------------------
    @staticmethod
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
        return out

    @classmethod
    def from_str(cls, name: str, step_csv: str) -> "Scale":
        """
        Construct from step sizes (e.g., '2,2,1,2,2,2,1'). Produces cumulative
        offsets starting at 0 -> [0,2,4,5,7,9,11] for a major scale.
        """
        steps = cls._parse_csv(step_csv)
        total = 0
        cumulative: List[int] = [0]
        for s in steps:
            total += s
            cumulative.append(total)
        intervals = [Interval(v) for v in cumulative]
        return cls(name=name.strip().lower(), intervals=intervals)

    # ---- Registry helpers ---------------------------------------------------
    @classmethod
    def register(cls, scale: "Scale", *, overwrite: bool = False, alias_of: Optional[str] = None) -> None:
        """
        Register a Scale under its name in the global registry.
        Optionally register this name as an alias of another canonical name.
        """
        key = scale.name
        if not overwrite and key in cls.registry:
            raise KeyError(f"Scale '{key}' already exists; use overwrite=True to replace.")
        cls.registry[key] = scale
        if alias_of:
            cls.aliases[key] = alias_of

    @classmethod
    def register_from_steps(cls, name: str, step_csv: str, *, overwrite: bool = False) -> "Scale":
        sc = cls.from_steps(name, step_csv)
        cls.register(sc, overwrite=overwrite)
        return sc

    @classmethod
    def get(cls, name: str) -> "Scale":
        """
        Retrieve a Scale by name or alias (case-insensitive).
        Raises KeyError if not found.
        """
        key = name.strip().lower()
        # resolve alias chain if present
        canon = cls.aliases.get(key, key)
        try:
            return cls.registry[canon]
        except KeyError as exc:
            available = ", ".join(sorted(cls.registry))
            raise KeyError(f"Unknown scale '{name}'. Available: {available}") from exc

    # ---- Utilities ----------------------------------------------------------
    def to_notes(self, root_note) -> List:
        """
        Given a Note return the concrete notes in this scale.
        This avoids importing Note here to keep interval-only usage lightweight.
        """
        # lazy import to avoid circular import weight at module load time
        from .note import Note  # type: ignore
        if not isinstance(root_note, Note):
            raise TypeError("root_note must be a tedesco.note.Note instance")
        return [root_note + iv for iv in self.intervals]

    def pitch_classes(self, root_pc: int) -> List[int]:
        """
        Given a root pitch class (0..11), return the pitch classes of the scale (mod 12).
        """
        if not isinstance(root_pc, int):
            raise TypeError("root_pc must be int")
        return [((root_pc + iv.semitones) % 12) for iv in self.intervals]
        
def get_scale_intervals(name: str) -> list[Interval]:
    """
    Return a list of Interval objects for the named scale.

    Parameters
    ----------
    name : str
        Scale name (case-insensitive). e.g., "major", "dorian", "minor_pentatonic".

    Returns
    -------
    list[Interval]
    """
    key = _resolve_name(name)
    try:
        csv = SCALE_PATTERNS[key]
    except KeyError as exc:
        available = ", ".join(sorted(SCALE_PATTERNS))
        raise KeyError(f"Unknown scale '{name}'. Available: {available}") from exc
    return Interval.list_from_string(csv, cumulative=True)
