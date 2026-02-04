from __future__ import annotations
from dataclasses import dataclass
from functools import total_ordering
from typing import ClassVar

@total_ordering
@dataclass(frozen=True)
class Interval:
    """A chromatic interval measured in semitones (can be negative)."""
    semitones: int

    """Well-known values"""
    Unison: ClassVar["Interval"]
    MinorSecond: ClassVar["Interval"]
    MajorSecond: ClassVar["Interval"]
    MinorThird: ClassVar["Interval"]
    MajorThird: ClassVar["Interval"]
    PerfectFourth: ClassVar["Interval"]
    Tritone: ClassVar["Interval"]
    Fifth: ClassVar["Interval"]
    MinorSixth: ClassVar["Interval"]
    MajorSixth: ClassVar["Interval"]
    MinorSeventh: ClassVar["Interval"]
    MajorSeventh: ClassVar["Interval"]
    Octave: ClassVar["Interval"]

    def __repr__(self) -> str:
        sign = "+" if self.semitones >= 0 else "-"
        return f"<Interval {sign}{abs(self.semitones)} st>"
    
    # ---- comparisons required by @total_ordering ----
    def __eq__(self, other: object) -> bool:
        if not isinstance(other, Interval):
            return NotImplemented
        return self.semitones == other.semitones

    def __lt__(self, other: "Interval") -> bool:
        if not isinstance(other, Interval):
            return NotImplemented
        return self.semitones < other.semitones
    
    def __add__(self, other):
        try:
            from .note import Note  # Lazy imported here to avoid circular import
        except:
            Note = None
        if (Note is not None and isinstance(other, Note)):
            return other + self
        return NotImplemented

    def __mul__(self, other):
        raise TypeError("Interval objects do not support multiplication")
    
    def __rmul__(self, other):
        raise TypeError("Interval objects do not support multiplication")
    
    def __truediv__(self, other):
        raise TypeError("Interval objects do not support division")
    
    def __floordiv__(self, other):
        raise TypeError("Interval objects do not support division")
    
    def __mod__(self, other):
        raise TypeError("Interval objects do not support modulo")

    def relatedTo(self, other: "Interval") -> bool:
        if not isinstance(other, Interval):
            return NotImplemented

        return self.semitones % 12 == other.semitones % 12
        
# Define the static singletons *after* the class is created.
Interval.Unison         = Interval(0)
Interval.MinorSecond    = Interval(1)
Interval.MajorSecond    = Interval(2)
Interval.MinorThird     = Interval(3)
Interval.MajorThird     = Interval(4)
Interval.PerfectFourth  = Interval(5)
Interval.Tritone        = Interval(6)
Interval.PerfectFifth   = Interval(7)  
Interval.MinorSixth     = Interval(8)
Interval.MajorSixth     = Interval(9)
Interval.MinorSeventh   = Interval(10)
Interval.MajorSeventh   = Interval(11)
Interval.Octave         = Interval(12)
