import re
import pytest

from tedesco.interval_pattern import IntervalPattern
from tedesco.note import Note

def test_pattern_must_not_be_blank():
    with pytest.raises(ValueError):
        IntervalPattern("")
    with pytest.raises(ValueError):
        IntervalPattern("           ")

def test_pattern_rejects_invalid_integer():
    with pytest.raises(ValueError, match="Invalid integer in csv"):
        IntervalPattern("0,foo,7")

def test_pattern_is_iterable():
    p = IntervalPattern("2,1")
    semis = [iv.semitones for iv in p]
    assert semis == [2, 1]
    assert len(p) == 2
    
def test_pattern_from_single_interval():
    i = IntervalPattern("3")
    assert len(i) == 1

def test_pattern_ignores_whitespace():
    j = IntervalPattern(" 2, 1  ")
    assert len(j) == 2

def test_pattern_from_wrong_type_throws():
    with pytest.raises(TypeError): 
        IntervalPattern(123)

def test_pattern_converts_to_list_of_notes():
    pattern = IntervalPattern("2, 1")
    root = Note(0, 4)
    assert len(pattern.to_notes(root)) == 3

def test_pattern_convert_bad_root_throws():
    with pytest.raises(TypeError): 
        IntervalPattern("2, 1").to_notes("not-a-note")

def test_pattern_non_stepped_preserves_distances():
    p = IntervalPattern("0,4,7", stepped=False)
    assert [iv.semitones for iv in p] == [0, 4, 7]

def test_pattern_non_stepped_can_be_unrooted():
    p = IntervalPattern("4,7", stepped=False)
    assert [iv.semitones for iv in p] == [4, 7]
    
