from tedesco.note import Note
from tedesco.string import String
from tedesco.fingerboard import Fingerboard
import pytest

def test_fingerboard_standard_tuning():
    fb = Fingerboard()
    assert fb.at(1, 0) == Note("E5")
    assert fb.at(6, 0) == Note("E3")

def test_fingerboard_notes_at_higher_frets():
    fb = Fingerboard()
    assert fb.at(1, 12) == Note("E6")
    assert fb.at(3, 5) == Note("F4")
  
