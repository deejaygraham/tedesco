import re
import pytest
from dataclasses import FrozenInstanceError
import operator

from tedesco.interval import Interval


def test_positive_intervals_are_valid():
    i = Interval(7)
    assert i.semitones == 7

def test_negative_intervals_are_valid():
    j = Interval(-3)
    assert j.semitones == -3

def test_zero_intervals_are_valid():
    k = Interval(0)
    assert k.semitones == 0

def test_interval_cannot_be_modified_after_creation():
    i = Interval(5)
    with pytest.raises(FrozenInstanceError):
        i.semitones = 6  # type: ignore[attr-defined]

def test_intervals_can_be_equal():
    a = Interval(7)
    b = Interval(7)
    assert a == b

def test_intervals_can_be_unequal():
    a = Interval(7)
    b = Interval(6)
    assert a != b

def test_interval_repr_format_positive():
    assert re.fullmatch(r"<Interval \+7 st>", repr(Interval(7)))

def test_interval_repr_format_negative():
    assert re.fullmatch(r"<Interval -3 st>", repr(Interval(-3)))

def test_interval_repr_format_zero():
    # zero uses + sign per implementation
    assert re.fullmatch(r"<Interval \+0 st>", repr(Interval(0)))

def test_interval_no_multiplication():
    i = Interval(5)
    with pytest.raises(TypeError):
        i * 2
    with pytest.raises(TypeError):
        2 * i

def test_interval_no_division():
    i = Interval(5)
    with pytest.raises(TypeError):
        i / 2
    with pytest.raises(TypeError):
        i // 2
    with pytest.raises(TypeError):
        i % 2

def test_add_with_unsupported_type_raises_typeerror():
    i = Interval(2)
    # Interval.__add__ returns NotImplemented for non-Note types,
    # which Python turns into a TypeError when used directly.
    with pytest.raises(TypeError):
        _ = i + 123

    with pytest.raises(TypeError):
        _ = i + object()

def test_interval_less_than_comparison():
    assert Interval.PerfectFifth < Interval.Octave

def test_interval_less_than_equal_comparison():
    assert Interval.PerfectFifth <= Interval(7)

def test_interval_greater_than_comparison():
    assert Interval.Octave > Interval(1)

def test_interval_greater_than_equal_comparison():
    assert Interval.Octave >= Interval(12)

def test_well_known_intervals_are_equal_to_plain():
    assert Interval(5) == Interval.PerfectFourth

def test_intervals_separated_by_octave_are_related():
    assert Interval(2).relatedTo(Interval(14))

def test_intervals_unrelated_intervals_are_not_related():
    assert not Interval(2).relatedTo(Interval(1))
    
def test_interval_as_solfege():
    assert Interval(0).asSolfege() == "do"
    assert Interval(2).asSolfege() == "re"
    assert Interval.Octave.asSolfege() == "do"

def test_interval_solfege_wraps_around():
    assert Interval(0).asSolfege() == Interval(12).asSolfege()
    
