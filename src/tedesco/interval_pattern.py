from __future__ import annotations

from dataclasses import dataclass
from typing import ClassVar, Dict, Iterable, Iterator, List, Optional

from .interval import Interval
from .note import Note

def list_from_string(csv: str, cumulative: bool = False) -> list["Interval"]:
    """
    Parse a comma-separated string of integers and build a list of Intervals.
    
    Parameters
    ----------
    csv : str
        Comma-separated integers. Examples:
          - Degrees: "0,2,4,5,7,9,11" (major scale) or "0,4,7" (major triad)
          - Steps:   "2,2,1,2,2,2,1"  
    cumulative : bool
        If True, treat the numbers as step sizes and produce cumulative offsets
        starting at 0. If False, use the numbers directly as semitone values.
    
    Returns
    -------
    list[Interval]
    """
    if not isinstance(csv, str):
        raise TypeError("csv must be a string of comma-separated integers")

    numbers: list[int] = []
    for raw in csv.split(","):
        token = raw.strip()
        if token == "":
            continue
        try:
            n = int(token)
        except ValueError as exc:
            raise ValueError(f"Invalid integer in csv: {token!r}") from exc
        
        numbers.append(n)

        if cumulative:
            total = 0
            values: list[int] = [total]  # start at 0 semitones (root)
            for step in numbers:
                total += step
                values.append(total)
        else:
            values = numbers

        return [Interval(v) for v in values]


class IntervalPattern:
    """
    An interval pattern defined by cumulative semitone offsets from an implied root.

    Examples
    --------
    major_scale = IntervalPattern("2,2,1,2,2,2,1") 
    """
    intervals: list[Interval]

    def __init__(self, pattern: str):
        if not pattern or not pattern.strip():
            raise ValueError("Pattern string must be non-empty")
            
        degrees = list_from_string(pattern, cumulative = True)
        self.intervals = [Interval(i) for i in degrees]
            
    # ---- Basic dunder helpers ----------------------------------------------
    def __iter__(self) -> Iterator[Interval]:
        return iter(self.intervals)

    def __len__(self) -> int:
        return len(self.intervals)

    def __contains__(self, item: Interval) -> bool:
        return item in self.intervals
        
    def to_notes(self, root: Note) -> list["Note"]:
        """
        Given a Note return the concrete list notes in this pattern.
        """
        if not isinstance(root, Note):
            raise TypeError("root must be a tedesco.Note instance")
        return [root + i for i in self.intervals]
        
