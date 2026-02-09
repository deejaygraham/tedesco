from tedesco.ascii_fretboard_renderer import render_fretboard
import pytest 

def test_default_fretboard_basic_shape():
    out = render_fretboard()
    lines = out.splitlines()
    # header + 6 string rows + marker row + marker-number row
    assert len(lines) >= 8
    assert "0" in lines[0]          # fret 0 label
    assert lines[1].startswith("e'")  # top string label for high E

def test_fretboard_scale_filter_and_root_highlight():
    out = render_fretboard(scale_root="C", scale_name="major", show_all_notes=False)
    # Root C should appear uppercased somewhere
    assert "C" in out

def test_fretboard_rejects_negative_frets():
    from tedesco.ascii_fretboard_renderer import render_fretboard
    with pytest.raises(ValueError):
        render_fretboard(num_frets=-1)

def test_fretboard_rejects_unknown_tuning_note():
    from tedesco.ascii_fretboard_renderer import render_fretboard
    with pytest.raises(ValueError):
        render_fretboard(tuning=["E", "A", "D", "G", "B", "H"])  # H not valid  
