from __future__ import annotations

import pytest

from tedesco.chord import Chord
from tedesco.interval import Interval
from tedesco.note import Note


def test_chord_constructed_from_known_name():#
    root = Note(0, 4)
    c = Chord(root,"maj7")
    assert [iv.pitch_class for iv in c] == [0, 4, 7, 11]

def test_chord_constructed_from_unknown_name_throws():
    with pytest.raises(ValueError): 
        Chord(Note(0, 4), "lost chord")
        
def test_chord_constructed_from_custom_intervals():
    root = Note(0, 4)#
    c = Chord(root,"0,3,7,10") 
    assert [iv.pitch_class for iv in c] == [0, 3, 7, 10]


def test_chord_allows_inversion_forms():
    root = Note(0, 4)#
    c = Chord(root, "4,7,11")  # major 7th chord with missing root
    assert [iv.pitch_class for iv in c] == [4, 7, 11]
