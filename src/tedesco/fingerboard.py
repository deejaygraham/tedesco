from __future__ import annotations
from .note import Note
from .string import String

class Fingerboard:
    """Models a guitar fingerboard"""

    def __init__(self):
        """Initializes the fingerboard with a standard six-string tuning"""
        self.strings = [
            String(1, Note.from_midi(64)),
            String(2, Note.from_midi(59)),
            String(3, Note.from_midi(55)),
            String(4, Note.from_midi(50)),
            String(5, Note.from_midi(45)),
            String(6, Note.from_midi(40)),
        ]

    def __str__(self):
        """Returns a string representation of the fingerboard"""
        return f"Fingerboard with {len(self.strings)} strings"

    def __eq__(self, other):
        """Checks if two fingerboards are equal"""
        return self.strings == other.strings

    def __hash__(self):
        """Returns a hash of the fingerboard"""
        return hash(tuple(self.strings))

    def at(self, string: int, fret: int) -> Note:
        s = next((o for o in self.strings if o.id == string), None)

        if s is None:
            return None
            
        return s.at(fret)
        
        
