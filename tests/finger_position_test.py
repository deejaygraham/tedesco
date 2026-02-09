from tedesco.finger_position import FingerPosition
import pytest

def test_position_constructed_from_valid_location():
    p = FingerPosition(1, 9)
    assert p.fret == 9
    assert p.string == 1

def test_position_with_negative_fret_throws_error():
    with pytest.raises(ValueError):
        FingerPosition(1, -1)

def test_position_with_too_high_fret_throws_error():
    with pytest.raises(ValueError):
        FingerPosition(1, 25)

def test_position_with_too_low_string_throws_error():
    with pytest.raises(ValueError):
        FingerPosition(7, 0)

def test_position_with_too_high_string_throws_error():
    with pytest.raises(ValueError):
        FingerPosition(0, 0)

def test_position_same_positions_are_equal():
    assert FingerPosition(1, 9) == FingerPosition(1, 9)

def test_position_different_strings_are_not_equal():
    assert FingerPosition(1, 9) != FingerPosition(2, 9)

def test_position_different_frets_are_not_equal():
    assert FingerPosition(1, 19) == FingerPosition(1, 9)
