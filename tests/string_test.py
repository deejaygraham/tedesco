from tedesco.note import Note
from tedesco.string import String
import pytest

def test_string_created_with_string_and_note():
    high_e = String(1, Note("E5"))
    assert high_e.tuning == Note("E5")

def test_string_can_be_retuned():
    high_e = String(1, Note("E5"))
    high_e.tune_to(Note("A2"))
    assert high_e.tuning == Note("A2")

def test_string_note_at_fret_is_higher_than_open():
    s = String(1, Note("E5"))
    assert s.at_fret(1) > s.at_fret(0)
    assert s.at_fret(12) > s.at_fret(5)

def test_string_same_note_same_number_are_equal():
    assert String(1, Note("E5")) == String(1, Note("E5"))

def test_string_same_note_different_number_not_equal():
    assert String(1, Note("E5")) != String(2, Note("E5"))

def test_string_different_note_same_number_not_equal():
    assert String(1, Note("E5")) != String(1, Note("F5"))

def test_string_unknown_number_throws():
    with pytest.raises(ValueError):
        String(0, Note("F4"))

    with pytest.raises(ValueError):
        String(7, Note("G6"))

def test_string_note_behind_nut_throws():
    with pytest.raises(ValueError):
        String(1, Note("E5")).at_fret(-1)
        
