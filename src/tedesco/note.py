from __future__ import annotations
from functools import total_ordering
import re
from .interval import Interval

# Map canonical sharp spellings to semitone offsets (C=0)
_SEMITONES_SHARP = {
    "C": 0, "C#": 1, "D": 2, "D#": 3, "E": 4,
    "F": 5, "F#": 6, "G": 7, "G#": 8, "A": 9,
    "A#": 10, "B": 11,
}

# Common enharmonic flat -> sharp normalization
_ENHARMONIC_TO_SHARP = {
    "Cb": "B",  "B#": "C",
    "Db": "C#", "Eb": "D#", "Fb": "E", "E#": "F",
    "Gb": "F#", "Ab": "G#", "Bb": "A#",
    # Unicode accidentals
    "C♭": "B",  "B♯": "C",
    "D♭": "C#", "E♭": "D#", "F♭": "E", "E♯": "F",
    "G♭": "F#", "A♭": "G#", "B♭": "A#",
}

# Regex: letter A–G, optional accidental (#, b, ♯, ♭), then octave int (optional sign)
_SPN_RE = re.compile(r"""
    ^\s*
    (?P<letter>[A-Ga-g])
    (?P<accidental>[#b♯♭]?)      # optional accidental
    (?P<octave>[+-]?\d+)         # required octave
    \s*$
""", re.VERBOSE)


@total_ordering
class Note:
    """
    Musical note based on scientific pitch notation
    """
    __slots__ = ("_midi", "_base_octave")

    def __init__(self, spn: str, *, base_octave: int = -1):
        """
        Construct a Note from scientific pitch notation (e.g., 'C4', 'F#3', 'Db5', 'A♭4').
        Internally stores MIDI (int). Raises ValueError on invalid input or MIDI range.

        base_octave controls the octave numbering convention:
          -1 : MIDI standard (C-1 = 0, C4 = 60)
           0 : C0 = 0 (used by some DAWs)
        """
        m = _SPN_RE.match(spn)
        if not m:
            raise ValueError(f"Invalid scientific pitch notation: {spn!r}")

        letter = m.group("letter").upper()
        acc = m.group("accidental")
        octave = int(m.group("octave"))

        # Normalize accidental to ASCII symbols where applicable
        if acc == "♯":
            acc = "#"
        elif acc == "♭":
            acc = "b"

        token = letter + acc

        # Normalize flats (and some edge enharmonics) to sharp names
        if token in _ENHARMONIC_TO_SHARP:
            token = _ENHARMONIC_TO_SHARP[token]

        if token not in _SEMITONES_SHARP:
            # Handles rare double accidentals or unsupported spellings
            raise ValueError(f"Unsupported or unrecognized pitch class: {letter}{acc}")

        semitone = _SEMITONES_SHARP[token]
        midi = (octave - base_octave) * 12 + semitone
        if not (0 <= midi <= 127):
            raise ValueError(f"MIDI value out of 0–127 range for {spn!r}: {midi}")

        self._midi = midi
        self._base_octave = base_octave

    @classmethod
    def from_midi(cls, midi: int) -> Note:
        """
        Construct from a MIDI integer (0–127). Uses sharp spelling for pitch.
        """
        if not isinstance(midi, int):
            raise TypeError("midi must be an int")
        if not (0 <= midi <= 127):
            raise ValueError("midi must be in 0–127")
        octave = midi // 12 - 1
        semitone = midi % 12
        pitch = cls._pitch_from_semitone(semitone)
        return cls(f"{pitch}{octave}")
     
    @property
    def name(self) -> str:
        """
        Alias for str(self): normalized SPN with sharps.
        """
        return str(self)
        
    @property
    def midi(self) -> int:
        """Return the MIDI integer value (0–127)."""
        return self._midi

    @property
    def octave(self) -> int:
        """Return the octave number according to scientific pitch notation."""
        return (self._midi // 12) + self._base_octave

    @property
    def pitch(self) -> str:
        """
        Return the pitch class as a canonical sharp name, e.g., 'C', 'C#', 'D', ..., 'B'.
        """
        return self._pitch_from_semitone(self._midi % 12)     

    def __eq__(self, other: object) -> bool:
        if not isinstance(other, Note):
            return NotImplemented
        return self._midi == other._midi

    def __lt__(self, other: object) -> bool:
        if not isinstance(other, Note):
            return NotImplemented
        return self._midi < other._midi
        
    def __str__(self) -> str:
        """Return a normalized scientific pitch name using sharps, e.g., 'C#4'."""
        return f"{self.pitch}{self.octave}"

    def __repr__(self) -> str:
        return f"Note({str(self)!r})"
        
    def transpose(self, semitones: int) -> Note:
        """
        Return a new Note transposed by the given number of semitones.
        """
        new_midi = self._midi + semitones
        if not (0 <= new_midi <= 127):
            raise ValueError(f"Transposition leads to out-of-range MIDI: {new_midi}")
        return Note.from_midi(new_midi)

    @staticmethod
    def _pitch_from_semitone(semitone: int) -> str:
        """Map 0–11 semitone to canonical sharp pitch class."""
        for name, val in _SEMITONES_SHARP.items():
            if val == semitone:
                return name
        # Should never happen
        raise RuntimeError(f"Invalid semitone: {semitone}")

    def __sub__(self, other) -> Interval:
        """
        Chromatic subtraction: returns Interval in semitones.
        Example: Note('E4') - Note('C4') -> Interval(4)
        """
        if isinstance(other, Note):
            return Interval(self._midi - other._midi)
        return NotImplemented

    def __add__(self, interval) -> "Note":
        """
        Transposition: Note + Interval -> Note
        """
        if isinstance(interval, Interval):
            return Note.from_midi(self._midi + interval.semitones)
        return NotImplemented

    def __radd__(self, interval: Interval) -> "Note":
        """
        Allow Interval + Note -> Note
        """
        return self.__add__(interval);
