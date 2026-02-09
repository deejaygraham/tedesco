from __future__ import annotations

from dataclasses import dataclass
from typing import Dict, Iterator, List

from .interval import Interval
from .interval_pattern import IntervalPattern
from .note import Note

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


@dataclass(frozen=False)
class Chord:
    """
    A chord represented as a list of cumulative semitone intervals above the root.
    """
    notes: list[Note]

    def __init__(self, root: Note, pattern: str) -> "Chord":
        if not isinstance(pattern, str):
            raise TypeError("Pattern must be a string of comma-separated integers")
        
        if not pattern or not pattern.strip():
            raise ValueError("Pattern string must be non-empty")
            
        if pattern in KNOWN_CHORD_PATTERNS:
            values = KNOWN_CHORD_PATTERNS[pattern]
        else:
            values = pattern
            
        self.notes = IntervalPattern(values, stepped=False).to_notes(root)
      
    # ---- Basic container protocol ------------------------------------------
    def __iter__(self) -> Iterator[Interval]:
        return iter(self.notes)

    def __len__(self) -> int:
        return len(self.notes)

    def __contains__(self, item: Interval) -> bool:
        return item in self.notes
