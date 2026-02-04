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

def test_interval_can_be_multiplied_by_integer():
    i = Interval(3)
    assert (i * 2).semitones == 6
    assert (2 * i).semitones == 6

    j = Interval(-4)
    assert (j * 3).semitones == -12
    assert (3 * j).semitones == -12

    # identity and zero
    assert (i * 1).semitones == 3
    assert (i * 0).semitones == 0

def test_interval_multiplied_by_float_throws_error():
    i = Interval(5)
    # Unsupported scalar types should return NotImplemented → TypeError
    with pytest.raises(TypeError):
        _ = i * 2.5  # float not supported

def test_interval_multiplied_by_string_throws_error():
    i = Interval(5)
    with pytest.raises(TypeError):
        _ = "x" * i  # __rmul__ only supports int, not str-left

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
    
def test_interval_well_known_multiplication():
    assert Interval.MajorThird * 2 == Interval.MajorSixth
    assert 2 * Interval.Fifth == Interval(14)

def test_well_known_intervals_are_equal_to_plain():
    assert Interval(5) == Interval.Fourth
