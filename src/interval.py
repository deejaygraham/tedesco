from __future__ import annotations
from dataclasses import dataclass

@dataclass(frozen=True)
class Interval:
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
        return Interval(self.semitones * k)

    __rmul__ = __mul__
