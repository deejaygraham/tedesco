from math import log2

def midi_from_frequency(frequency: float) -> int:
    """Converts a frequency to a MIDI note number.
    Args:
        frequency (float): The frequency in Hz
    Returns:
        int: The MIDI note number
    """
    # Standard MIDI formula: A4 (440 Hz) = MIDI note 69
    # frequency = 440 * 2^((midi_note - 69) / 12)
    # Solving for midi_note: midi_note = 69 + 12 * log2(frequency / 440)
    midi_note = int(round(69 + 12 * log2(frequency / 440)))
    return midi_note


def frequency_from_midi(midi_note: int) -> float:
    """Converts a MIDI note number to a frequency.
    Args:
        midi_note (int): The MIDI note number
    Returns:
        float: The frequency in Hz
    """
    return 440 * 2 ** ((midi_note - 69) / 12)
  
