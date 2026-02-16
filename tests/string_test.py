from tedesco.note import Note
from tedesco.string import String
import pytest

def test_string_created_with_string_and_note():
    high_e = String(Note(1, "E5"))
                    
