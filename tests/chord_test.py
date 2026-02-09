from __future__ import annotations

import pytest

from tedesco.chord import Chord
from tedesco.interval import Interval
from tedesco.note import Note


def test_chord_constructed_from_known_name():#
    root = Note(0, 4)
    c = Chord(root,"maj7")
    assert [iv.pitch_class for iv in c] == [0, 4, 7, 11]

def test_min7_chord_from_name():
    root = Note(0, 4)  # C4
    c = Chord(root, "min7")
    assert [n.pitch_class for n in c] == [0, 3, 7, 10]
    
def test_chord_constructed_from_unknown_name_throws():
    with pytest.raises(ValueError): 
        Chord(Note(0, 4), "lost chord")

def test_chord_blank_pattern_throws():
    root = Note(0, 4)
    with pytest.raises(ValueError):
        Chord(root, "")
    with pytest.raises(ValueError):
        Chord(root, "    ")

def test_chord_constructed_with_bad_string_throws():
    with pytest.raises(ValueError): 
        Chord(Note(0, 4), "0,foo,7")

def test_chord_constructed_from_custom_intervals():
    root = Note(0, 4)#
    c = Chord(root,"0,3,7,10") 
    assert [iv.pitch_class for iv in c] == [0, 3, 7, 10]

def test_chord_constructed_from_bad_type_throws():
    with pytest.raises(TypeError): 
        Chord(Note(0, 4), 123)

def test_chord_allows_inversion_forms():
    root = Note(0, 4)#
    c = Chord(root, "4,7,11")  # major 7th chord with missing root
    assert [iv.pitch_class for iv in c] == [4, 7, 11]

def test_chord_is_iteratable():
    len(list(Chord(Note(0, 4), "maj7"))) == 4

def test_chord_contains_root_note():
    root = Note(0, 4)
    c = Chord(root, "maj7")
    assert root in c

def test_chord_does_not_contain_unrelated_note():
    root = Note(0, 4)
    c = Chord(root, "maj7")
    assert Note(1, 4) not in c  # C# not in Cmaj7
