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


#def test_midi_from_frequency(self):
#   """Test the calculation of the MIDI from frequency"""
#    self.assertEqual(midi_from_frequency(440.0), 69)
#    self.assertEqual(midi_from_frequency(8.175), 0)
#     self.assertEqual(midi_from_frequency(12543.85), 127)
#     self.assertEqual(note_name_from_midi(midi_from_frequency(440.0)), "A4")
#    self.assertEqual(note_name_from_midi(midi_from_frequency(8.175)), "C-1")
#     self.assertEqual(note_name_from_midi(midi_from_frequency(12543.85)), "G8")
#
#  def test_frequency_from_midi(self):
#      """Test the calculation of the frequency from MIDI"""
#      self.assertAlmostEqual(frequency_from_midi(0), 8.176, places=3)
#      self.assertAlmostEqual(frequency_from_midi(69), 440.0, places=1)
#      self.assertAlmostEqual(frequency_from_midi(127), 12543.85, places=2)
