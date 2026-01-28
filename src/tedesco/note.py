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


# A default way to stringify back to a name (choose sharps by default)
_PC_TO_NAME = {
    0: "C",  1: "C#", 2: "D",  3: "D#", 4: "E",  5: "F",
    6: "F#", 7: "G",  8: "G#", 9: "A", 10: "A#", 11: "B",
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
        """Absolute semitone using C0 as 0, i.e., pc + 12*oct."""
        return self.pitch_class + 12 * self.octave

    @staticmethod
    def from_absolute_semitone(abs_st: int) -> "Note":
        """Inverse of absolute_semitone, normalizing to 0..11 pitch class."""
        octave, pc = divmod(abs_st, 12)
        return Note(pc, octave)

    def name(self, prefer_sharps: bool = True) -> str:
        """
        Returns a display name for the pitch class. For simplicity, this
        prefers sharps by default. (Enharmonic spelling control is minimal.)
        """
        if prefer_sharps:
            return _PC_TO_NAME[self.pitch_class]
        # quick flat-oriented mapping
        sharp_to_flat = {"C#": "Db", "D#": "Eb", "F#": "Gb", "G#": "Ab", "A#": "Bb"}
        sharp_name = _PC_TO_NAME[self.pitch_class]
        return sharp_to_flat.get(sharp_name, sharp_na
                                 
    def __repr__(self) -> str:
        return f"<Note {self.name()}{self.octave}>"

    def __sub__(self, other) -> Interval:
        """
        Chromatic subtraction: returns Interval in semitones.
        Example: Note('E4') - Note('C4') -> Interval(4)
        """
        if isinstance(other, Note):
            return Interval(self.absolute_semitone - other.absolute_semitone)
        return NotImplemented

    def __add__(self, interval) -> "Note":
        """
        Transposition: Note + Interval -> Note
        """
        if isinstance(interval, Interval):
            return Note.from_absolute_semitone(self.absolute_semitone + interval.semitones)
        return NotImplemented

    
    def __radd__(self, interval: Interval) -> "Note":
        """
        Allow Interval + Note -> Note
        """
        return self.__add__(interva

