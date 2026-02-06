import re
import pytest

from tedesco.interval_pattern import IntervalPattern

def test_pattern_must_not_be_blank():
    with pytest.raises(TypeError):
        IntervalPattern("")
    with pytest.raises(TypeError):
        IntervalPattern("           ")
      
def test_pattern_from_single_interval():
    i = IntervalPattern("3")
    assert len(i.intervals) == 2

def test_pattern_ignores_whitespace():
    j = IntervalPattern(" 2, 1  ")
    assert len(j) == 3

def test_pattern_contains_correct_intervals():
  pass
