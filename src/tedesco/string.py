from __future__ import annotations
from typing import Final
import re
from .note import Note
from .interval import Interval

MIN_STRING_ID: Final[int] = 1
MAX_STRING_ID: Final[int] = 6
MIN_FRET: Final[int] = 0
MAX_FRET: Final[int] = 24

class String:
    """Models a guitar string"""

    __slots__ = ("_number", "_tuning")

    def __init__(self, string_number: int, tuning: Note):
        """Initializes the string with a number and a midi tuning"""
        if not isinstance(string_number, int):
            raise TypeError(f"string_number must be int, got {type(string_number).__name__}")
        if string_number < MIN_STRING_ID or string_number > MAX_STRING_ID:
            raise ValueError(
                f"string_number out of bounds [{MIN_STRING_ID}, {MAX_STRING_ID}]: {string_number}"
            )
        if not isinstance(tuning, Note):
            raise TypeError(f"tuning must be a Note, got {type(tuning).__name__}")

        self._number = string_number
        self._tuning = tuning

    def __str__(self):
        """Returns a string representation of the string"""
        return f"String {self._number}"

    def __eq__(self, other):
        """Checks if two strings are equal"""
        return self._number == other._number and self._tuning == other._tuning

    def __hash__(self):
        """Returns a hash of the string"""
        return hash((self._number, self._tuning))

    def __iter__(self) -> Iterator[Interval]:
        return iter([self._tuning + Interval(i) for i in range(MAX_FRET)])

    def __len__(self) -> int:
        return MAX_FRET
        
    def tune_to(self, tuning: Note):
        """Tunes the string to a given tuning"""
        if not isinstance(tuning, Note):
            raise ValueError(f"Tuning must be a valid note")
            
        self._tuning = tuning

    @property
    def id(self) -> int:
        return self._number
    
    @property
    def tuning(self) -> Note:
        return self._tuning
    
    def at(self, fret: int) -> Note:
        """Returns the value of the string at a given fret"""
        if fret < MIN_FRET or fret > MAX_FRET:
            raise ValueError("Fret number must be between 0 and 24")
            
        return self.tuning + Interval(fret)
