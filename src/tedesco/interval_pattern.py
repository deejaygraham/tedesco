from __future__ import annotations

from dataclasses import dataclass
from typing import ClassVar, Dict, Iterable, Iterator, List, Optional

from .interval import Interval
from .note import Note

def _parse_csv(csv: str) -> List[int]:
    """
    Parse a CSV of cumulative semitone offsets.
    Ensures the root (0) is present and raises on empty/invalid input.
    """
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
  
    return out
        
class IntervalPattern:
    """
    A musical pattern defined by cumulative semitone offsets from an implied root.

    Examples
    --------
    major_scale = IntervalPattern("2,2,1,2,2,2,1") 
    """
    intervals: List[Interval]

    def __init__(self, pattern: str):
        if not pattern or not pattern.strip():
            raise ValueError("CSV string must be non-empty")
            
        degrees = _parse_csv(pattern)
        self.intervals = [Interval(n) for n in degrees]
            
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
        
    def to_notes(self, root_note) -> List:
        """
        Given a Note return the concrete notes in this pattern.
        """
        if not isinstance(root_note, Note):
            raise TypeError("root_note must be a tedesco.Note instance")
        return [root_note + i for i in self.intervals]
        
