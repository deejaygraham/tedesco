import re
import pytest

from tedesco.interval_pattern import IntervalPattern
from tedesco.note import Note

def test_pattern_must_not_be_blank():
    with pytest.raises(ValueError):
        IntervalPattern("")
    with pytest.raises(ValueError):
        IntervalPattern("           ")
      
def test_pattern_from_single_interval():
    i = IntervalPattern("3")
    assert len(i.intervals) == 1

def test_pattern_ignores_whitespace():
    j = IntervalPattern(" 2, 1  ")
    assert len(j) == 2

def test_pattern_converts_to_notes():
    pattern = IntervalPattern("2, 1")
    root = Note(0, 4)
    assert len(pattern.to_notes(root)) == 3
