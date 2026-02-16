from tedesco.scale import Scale
from tedesco.interval import Interval
from tedesco.note import Note
import pytest

def test_scale_pitches_match_correct_scale():
    root = Note("C4")
    major_scale = Scale(root, "major")
    assert [iv.pitch for iv in major_scale] == ['C', 'D', 'E', 'F', 'G', 'A', 'B', 'C']
    assert len(major_scale) == 8

def test_scale_note_names_match_correct_scale():
    root = Note("C4")
    scale = Scale(root, "major")
    names = [n.name() for n in scale]
    assert names == ["C4", "D4", "E4", "F4", "G4", "A4", "B4", "C5"]

def test_scale_with_bad_root_throws():
    with pytest.raises(TypeError): 
        Scale("not-a-note", "major")

def test_scale_with_unknown_name_throws():
    with pytest.raises(ValueError): 
        Scale(Note("C4"), "unknown-scale")

def test_blank_name_throws_error():
    with pytest.raises(ValueError):
        Scale(Note("C4"), "")

def test_blank_csv_throws_error():
    with pytest.raises(ValueError):
        Scale(Note("C4"), " , , ")

def test_unknown_string_throws_error():
    with pytest.raises(ValueError):
        Scale(Note("C4"), "0,foo,7") 
