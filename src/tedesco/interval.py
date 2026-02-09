from __future__ import annotations
from dataclasses import dataclass
from functools import total_ordering
from typing import ClassVar

_NAME_TO_SEMITONES = {
    "unison": 0, 
    "minor second": 1, 
    "major second": 2, 
    "minor third": 3, 
    "major third": 4, 
    "perfect fourth": 5, 
    "diminished fifth": 6, 
    "perfect fifth": 7, 
    "minor sixth": 8, 
    "major sixth": 9, 
    "minor seventh": 10, 
    "major seventh": 11, 
    "octave": 12, 
    "minor ninth": 13, 
    "ninth": 14,
}

@total_ordering
@dataclass(frozen=True)
class Interval:
    """A chromatic interval measured in semitones (can be negative)."""
    semitones: int
    
    @classmethod
    def from_name(cls, name: str) -> "Interval":
        return cls(_NAME_TO_SEMITONES[name.strip().lower()])
        
    """Well-known values"""
    Unison: ClassVar["Interval"]
    HalfStep: ClassVar["Interval"]
    MinorSecond: ClassVar["Interval"]
    WholeStep: ClassVar["Interval"]
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
    MinorNinth: ClassVar["Interval"]
    Ninth: ClassVar["Interval"]

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

    def asSolfege(self) -> str:
        solfa = ["do", "di", "re", "ri", "mi", "fa", "fi", "so", "si", "la", "li", "ti"]

        degree = self.semitones % len(solfa)
        return solfa[degree]

    def name(self) -> str:
        names = [ "unison", "minor second", "major second", "minor third", "major third", "perfect fourth", "diminished fifth", 
                 "perfect fifth", "minor sixth", "major sixth", "minor seventh", "major seventh", "octave", "minor ninth", "ninth" ]
        
        distance = abs(self.semitones)

        if distance >= len(names):
            return "unknown"
            
        return names[distance]

        
# Define the static singletons *after* the class is created.
Interval.Unison         = Interval(0)
Interval.HalfStep       = Interval(1)
Interval.MinorSecond    = Interval(1)
Interval.MajorSecond    = Interval(2)
Interval.WholeStep      = Interval(2)
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
Interval.MinorNinth     = Interval(13)
Interval.Ninth          = Interval(14)

