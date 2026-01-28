from __future__ import annotations
from dataclasses import dataclass
from .interval import Interval

# canonical semitone index for pitch classes, 0..11 (C = 0)
_NAME_TO_PC = {
    # naturals
    "C": 0, "D": 2, "E": 4, "F": 5, "G": 7, "A": 9, "B": 11,
    # sharps
    "C#": 1, "D#": 3, "F#": 6, "G#": 8, "A#": 10,
    # flats
    "Db": 1, "Eb": 3, "Gb": 6, "Ab": 8, "Bb": 10,
    # optionals (enharmonics)
    "B#": 0, "E#": 5, "Cb": 11, "Fb": 4,
}


def _mod12(n: int) -> int:
    return n % 12


@dataclass(frozen=True)
class Note:
    """
    A pitch class + octave, with 12-TET semitone arithmetic.

    - pitch_class: 0..11 (C=0)
    - octave: integer (MIDI-like notion but not tied to MIDI numbers)
    """
    
    pitch_class: int
    octave: int

    
    @staticmethod
    def from_name(name: str, octave: int) -> "Note":
        """
        Construct from a note name like 'C', 'F#', 'Bb', 'Cb', 'E#' etc.
        """
        name = name.strip()
        if name not in _NAME_TO_PC:
            raise ValueError(f"Unknown note name: {name}")
        return Note(_NAME_TO_PC[name], octave)

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
