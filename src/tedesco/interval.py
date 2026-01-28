from __future__ import annotations
from dataclasses import dataclass

@dataclass(frozen=True)
class Interval:
    """A chromatic interval measured in semitones (can be negative)."""
    semitones: int

    def __repr__(self) -> str:
        sign = "+" if self.semitones >= 0 else "-"
        return f"<Interval {sign}{abs(self.semitones)} st>"

    def __add__(self, other):
        from .note import Note  # imported here to avoid circular import
        if isinstance(other, Note):
            return other + self
        return NotImplemented

    def __mul__(self, k: int) -> "Interval":
        # Accept only integers; reject floats and other types.
        # (bool is a subclass of int; if you want to reject True/False, add `and not isinstance(k, bool)`.)
        if isinstance(k, int):
            return Interval(self.semitones * k)
        return NotImplemented

    
    def __rmul__(self, k: int) -> "Interval":
        # Delegate to __mul__ so 2 * Interval(...) works the same as Interval(...) * 2
        return self.__mul__(k)
