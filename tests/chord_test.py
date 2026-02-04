from __future__ import annotations

import pytest

from tedesco.chord import Chord
from tedesco.interval import Interval
from tedesco.note import Note


def test_known_chord_name():
    c = Chord("maj7")
    assert [iv.semitones for iv in c] == [0, 4, 7, 11]


def test_custom_chord():
    c = Chord("0,3,7,10")  # min7
    assert [iv.semitones for iv in c] == [0, 3, 7, 10]


def test_csv_missing_root_is_normalized():
    c = Chord("4,7,11")  # maj7 missing 0
    assert [iv.semitones for iv in c] == [0, 4, 7, 11]
