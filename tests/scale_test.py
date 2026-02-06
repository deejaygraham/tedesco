from tedesco.scale import Scale
from tedesco.interval import Interval
from tedesco.note import Note
import pytest

def test_from_known_scale():
    sc = Scale("major")
    assert [iv.semitones for iv in sc] == [0, 2, 2, 1, 2, 2, 1]
    assert len(sc.degrees()) == 7

def test_from_interval_string():
    sc = Scale("0,3,7,10")
    assert [iv.semitones for iv in sc] == [0, 3, 7, 10]


def test_csv_normalizes_missing_root():
    sc = Scale("3,7,10")  # no leading 0; root will be prepended
    assert [iv.semitones for iv in sc] == [0, 3, 7, 10]


def test_to_notes():
    scale = Scale("major")
    root = Note(0, 4)
    names = [n.name() for n in scale.to_notes(root)]
    assert names == ["C", "D", "E", "F", "G", "A", "B"]


def test_blank_name_throws_error():
    with pytest.raises(ValueError):
        Scale("")

def test_blank_csv_throws_error():
    with pytest.raises(ValueError):
        Scale(" , , ")

def test_unknown_string_throws_error():
    with pytest.raises(ValueError):
        Scale("0,foo,7")
        
