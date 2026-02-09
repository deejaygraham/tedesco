from __future__ import annotations

import pytest

from tedesco.chord import Chord
from tedesco.interval import Interval
from tedesco.note import Note


#def test_known_chord_name():#
#    root = Note(0, 4)
#    c = Chord(root,"maj7")
#    assert [iv.pitch_class for iv in c] == [0, 4, 7, 11]


#def test_custom_chord():
#    root = Note(0, 4)#
#    c = Chord(root,"0,3,7,10")  # min7
#    assert [iv.pitch_class for iv in c] == [0, 3, 7, 10]


#def test_csv_missing_root_is_normalized():
#    root = Note(0, 4)#
#    c = Chord(root, "4,7,11")  # maj7 missing 0
#    assert [iv.pitch_class for iv in c] == [0, 4, 7, 11]
