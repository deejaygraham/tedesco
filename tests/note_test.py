import pytest

from tedesco.note import Note
from tedesco.interval import Interval

def test_negative_note_values_are_not_allowed():
    with pytest.raises(TypeError):
        _ = Note(-1)

def test_note_from_name_valid():
    c4 = Note.from_name("C", 4)
    assert c4.pitch_class == 0
    assert c4.octave == 4

def test_note_ignores_whitespace_name():
    fs3 = Note.from_name("  F#  ", 3)
    assert fs3.pitch_class == 6

def test_note_from_unknown_name_throws():
    with pytest.raises(ValueError):
        Note.from_name("H", 4)

def test_note_from_spn_parses_valid_string():
    c4 = Note.from_spn("C4")
    assert c4.pitch_class == 0
    assert c4.octave == 4

def test_note_from_spn_parses_whitespace_string():
    eb5 = Note.from_spn(" Eb5 ")
    assert eb5.pitch_class == 3
    assert eb5.octave == 5

def test_note_from_spn_rejects_invalid():
    with pytest.raises(ValueError):
        Note.from_spn("C")      # missing octave
    with pytest.raises(ValueError):
        Note.from_spn("H4")     # bad letter
    with pytest.raises(ValueError):
        Note.from_spn("C#4x")   # junk suffix

def test_note_distance_between_adjacent_notes_is_halfstep():
    assert abs((Note(0, 4) - Note(1, 4)).semitones) == 1

def test_note_distance_between_white_notes_is_wholestep():
    assert abs((Note(50, 4) - Note(52, 4)).semitones) == 2

def test_subtracting_one_note_from_another_returns_interval():
    c4 = Note(0, 4)   # C4
    e4 = Note(4, 4)   # E4 (4 semitones above C)
    i = e4 - c4
    assert isinstance(i, Interval)
    assert i.semitones == 4


def test_adding_interval_to_note_returns_note():
    c4 = Note(0, 4)
    fifth = Interval(7)
    g4 = c4 + fifth
    assert isinstance(g4, Note)
    assert g4.pitch_class == 7 and g4.octave == 4  # G4


def test_adding_note_and_interval_order_independent():
    c4 = Note(0, 4)
    m3 = Interval(3)
    assert (c4 + m3) == (m3 + c4)


def test_subtract_low_note_from_high_note_returns_positive_interval():
    lower = Note(0, 4)
    higher = Note(4, 4)
    i = higher - lower
    assert i.semitones == 4


def test_subtract_high_note_from_low_note_returns_negative_interval():
    lower = Note(0, 4)
    higher = Note(4, 4)
    i = lower - higher
    assert i.semitones == -4


def test_octave_wrap_on_addition():
    b4 = Note(11, 4)           # B4
    half_step = Interval(1)
    c5 = b4 + half_step
    assert c5.pitch_class == 0  # C
    assert c5.octave == 5


def test_from_absolute_semitone_and_roundtrip():
    # absolute semitone is pc + 12*octave with C0 == 0
    abs_st = 12 * 4 + 7  # G4
    g4 = Note.from_absolute_semitone(abs_st)
    assert g4.pitch_class == 7 and g4.octave == 4
    # Round-trip via subtraction
    c4 = Note(0, 4)
    assert (g4 - c4).semitones == 7


def test_negative_intervals_downward_transposition():
    c4 = Note(0, 4)
    m3_down = Interval(-3)
    a3 = c4 + m3_down
    assert a3.pitch_class == 9 and a3.octave == 3  # A3


def test_unrelated_types_return_not_implemented():
    c4 = Note(0, 4)
    with pytest.raises(TypeError):
        _ = c4 + 1  # not an Interval, should raise via NotImplemented -> TypeError
    with pytest.raises(TypeError):
        _ = c4 - 123  # not a Note

def test_note_from_midi_and_to_midi_roundtrip():
    c4 = Note.from_midi(60)       # middle C
    assert c4.pitch_class == 0
    assert c4.octave == 4
    assert c4.to_midi() == 60

def test_note_from_midi_requires_int():
    with pytest.raises(TypeError):
        Note.from_midi(60.5)

def test_note_name_prefers_sharps_and_flats():
    gsharp4 = Note.from_name("G#", 4)
    assert gsharp4.name() == "G#"
    assert gsharp4.name(prefer_sharps=False) == "Ab"

    bb3 = Note.from_name("Bb", 3)
    # prefer_sharps will show A#
    assert bb3.name() == "A#"
    # flat-oriented path returns Bb
    assert bb3.name(prefer_sharps=False) == "Bb"

def test_note_add_interval_and_reverse():
    c4 = Note(0, 4)
    m2 = Interval(2)
    d4 = c4 + m2
    assert d4.pitch_class == 2
    assert d4.octave == 4

    # Interval + Note via __radd__
    d4_b = m2 + c4
    assert d4_b == d4

def test_note_subtraction_returns_interval():
    c4 = Note(0, 4)
    e4 = Note.from_name("E", 4)
    interval = e4 - c4
    assert isinstance(interval, Interval)
    assert interval.semitones == 4   
