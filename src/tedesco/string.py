from __future__ import annotations
import re
from .note import Note
from .interval import Interval

class String:
    """Models a guitar string"""

    __slots__ = ("_number", "_tuning")

    def __init__(self, string_number: int, tuning: Note):
        """Initializes the string with a number and a midi tuning"""
        if string_number < 1 or string_number > 6:
            raise ValueError("String number must be between 1 and 6")
        if not isinstance(tuning, Note):
            raise ValueError(f"Tuning must be a valid note")

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
    
    def at_fret(self, fret: int) -> Note:
        """Returns the value of the string at a given fret"""
        if fret < 0 or fret > 24:
            raise ValueError("Fret number must be between 0 and 24")
            
        return self.tuning + Interval(fret)
