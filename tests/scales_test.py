from tedesco.scales import get_scale_intervals, SCALE_PATTERNS
from tedesco.interval import Interval

def test_major_scale_pattern_included_in_patterns():
    assert "major" in SCALE_PATTERNS
  
def test_major_scale_pattern_is_correct_intervals():
    xs = get_scale_intervals("major")
    assert [i.semitones for i in xs] == [0,2,4,5,7,9,11]

def test_minor_pentatonic_pattern():
    xs = get_scale_intervals("minor_pentatonic")
    assert [i.semitones for i in xs] == [0,3,5,7,10]

def test_unknown_scale_raises_keyerror():
    import pytest
    with pytest.raises(KeyError):
        get_scale_intervals("unknown-scale")
      
