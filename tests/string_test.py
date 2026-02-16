from tedesco.note import Note
from tedesco.string import String
import pytest

def test_string_created_with_string_and_note():
    high_e = String(1, Note("E5"))
    assert high_e.tuning == Note("E5")

def test_string_can_be_retuned():
    high_e = String(1, Note("E5"))
    high_e.tune(Note("A2"))
    assert high_e.tuning == Note("A2")

def test_string_note_at_fret_is_higher_than_open():
    s = String(1, Note("E5"))
    assert s.at_fret(1) > s.at_fret(0)
    assert s.at_fret(12) > s.at_fret(5)
    
