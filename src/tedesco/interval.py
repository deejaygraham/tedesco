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

    @staticmethod
    def list_from_string(
        csv: str,
        *,
        cumulative: bool = False
    ) -> list["Interval"]:
        """
        Parse a comma-separated string of integers and build a list of Intervals.

        Parameters
        ----------
        csv : str
            Comma-separated integers. Examples:
              - Offsets: "0,2,4,5,7,9,11"  (major scale)
              - Chord:   "0,4,7"           (major triad)
              - Steps:   "2,2,1,2,2,2,1"   (if cumulative=True -> 0,2,4,5,7,9,11)
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
            values: list[int] = [0]  # start at 0 semitones (root)
            for step in numbers:
                total += step
                values.append(total)
        else:
            values = numbers

        return [Interval(v) for v in values]
        
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

