from __future__ import annotations

from dataclasses import dataclass
from typing import ClassVar, Dict, Iterable, Iterator, List, Optional

from .interval import Interval
from .note import Note


class IntervalPattern:
    """
    An interval pattern defined by cumulative semitone offsets from an implied root.

    Examples
    --------
    major_scale = IntervalPattern("2,2,1,2,2,2,1", stepped=True)  
    major_chord = IntervalPattern("0, 4, 7", stepped=False)
    """
    intervals: list[Interval]
    stepped: bool
    
    def __init__(self, pattern: str, stepped: bool = True):
        if not isinstance(pattern, str):
            raise TypeError("pattern must be a string of comma-separated integers")
        
        if not pattern or not pattern.strip():
            raise ValueError("Pattern string must be non-empty")

        values: list[int] = []
        for raw in pattern.split(","):
            token = raw.strip()
            if token == "":
                continue
            try:
                n = int(token)
            except ValueError as exc:
                raise ValueError(f"Invalid integer in csv: {token!r}") from exc
            values.append(n)

        if len(values) == 0:
            raise ValueError("Pattern must contain at least one interval")
            
        self.stepped = stepped
        self.intervals = [Interval(i) for i in values]

            
    def __iter__(self) -> Iterator[Interval]:
        return iter(self.intervals)

    def __len__(self) -> int:
        return len(self.intervals)
        
    def to_notes(self, root: Note) -> list["Note"]:
        """
        Given a Note return the concrete list notes in this pattern.
        """
        if not isinstance(root, Note):
            raise TypeError("root must be a tedesco.Note instance")

        notes: list[Note] = []
        
        if self.stepped:
            notes.append(root)
            last = root
            for i in self.intervals:
                note = last + i
                notes.append(note)
                last = note
        else:
            for i in self.intervals:
                notes.append(root + i)
  
        return notes
