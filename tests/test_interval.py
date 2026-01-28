import re
import pytest
from dataclasses import FrozenInstanceError
import operator

from tedesco.interval import Interval


def test_interval_construction_and_value():
    i = Interval(7)
    assert i.semitones == 7

    j = Interval(-3)
    assert j.semitones == -3

    k = Interval(0)
    assert k.semitones == 0


def test_interval_is_frozen_immutable():
    i = Interval(5)
    with pytest.raises(FrozenInstanceError):
        i.semitones = 6  # type: ignore[attr-defined]


def test_equality_and_hashing():
    a = Interval(7)
    b = Interval(7)
    c = Interval(-7)
    assert a == b
    assert a != c

    # hashable & set behavior
    s = {a, b, c}
    assert len(s) == 2  # a and b collapse; c is distinct


def test_repr_format_positive_negative_zero():
    assert re.fullmatch(r"<Interval \+7 st>", repr(Interval(7)))
    assert re.fullmatch(r"<Interval -3 st>", repr(Interval(-3)))
    # zero uses + sign per implementation
    assert re.fullmatch(r"<Interval \+0 st>", repr(Interval(0)))


def test_scalar_multiplication_left_and_right():
    i = Interval(3)
    assert (i * 2).semitones == 6
    assert (2 * i).semitones == 6

    j = Interval(-4)
    assert (j * 3).semitones == -12
    assert (3 * j).semitones == -12

    # identity and zero
    assert (i * 1).semitones == 3
    assert (i * 0).semitones == 0


def test_scalar_multiplication_type_errors():
    i = Interval(5)
    # Unsupported scalar types should return NotImplemented → TypeError
    with pytest.raises(TypeError):
        _ = i * 2.5  # float not supported

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


def test_notimplemented_protocol_for_float():
    i = Interval(5)
    assert Interval.__mul__(i, 2.5) is NotImplemented
    # Using operator.mul triggers Python’s numeric protocol -> TypeError
    with pytest.raises(TypeError):
        operator.mul(i, 2.5)

