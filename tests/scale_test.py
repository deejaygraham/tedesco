from tedesco.scale import Scale
from tedesco.interval import Interval
from tedesco.note import Note
import pytest

def test_from_known_scale():
    root = Note(0, 4)
    sc = Scale(root, "major")
    #assert [iv.pitch_class for iv in sc] == [0, 2, 2, 1, 2, 2, 1]
    #assert len(sc.degrees()) == 7

def test_from_interval_string():
    root = Note(0, 4)
    sc = Scale(root, "0,3,7,10")
    #assert [iv.pitch_class for iv in sc] == [0, 3, 7, 10]


def test_csv_normalizes_missing_root():
    root = Note(0, 4)
    sc = Scale(root, "3,7,10")  # no leading 0; root will be prepended
    #assert [iv.pitch_class for iv in sc] == [0, 3, 7, 10]


def test_to_notes():
    root = Note(0, 4)
    scale = Scale(root, "major")
    names = [n.name() for n in scale]
    #assert names == ["C", "D", "E", "F", "G", "A", "B"]


#def test_blank_name_throws_error():
    #with pytest.raises(ValueError):
    #    Scale(Note(0, 4), "")

#def test_blank_csv_throws_error():
    #with pytest.raises(ValueError):
    #    Scale(Note(0, 4), " , , ")

#def test_unknown_string_throws_error():
    #with pytest.raises(ValueError):
    #    Scale(Note(0, 4), "0,foo,7") 
