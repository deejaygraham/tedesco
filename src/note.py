from __future__ import annotations
from dataclasses import dataclass
from .interval import Interval

@dataclass(frozen=True)
class Note:
    pitch_class: int
    octave: int

    @property
    def absolute_semitone(self) -> int:
        return self.pitch_class + 12 * self.octave

    @staticmethod
    def from_absolute_semitone(abs_st: int) -> "Note":
        octave, pc = divmod(abs_st, 12)
        return Note(pc, octave)

    def __sub__(self, other) -> Interval:
        if isinstance(other, Note):
            return Interval(self.absolute_semitone - other.absolute_semitone)
        return NotImplemented

    def __add__(self, interval) -> "Note":
        if isinstance(interval, Interval):
            return Note.from_absolute_semitone(self.absolute_semitone + interval.semitones)
        return NotImplemented

    __radd__ = __add__
