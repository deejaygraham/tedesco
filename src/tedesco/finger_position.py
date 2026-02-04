from __future__ import annotations

class FingerPosition:
  
    def __init__(self, string: int, fret: int):
        self.string = string  # 6=low E, 1=high E
        self.fret = fret
      
    def __eq__(self, other: FingerPosition) -> bool:
        return isinstance(other, FingerPosition) and self.string == other.string and self.fret == other.fret
      
    def __hash__(self):
        return hash((self.string, self.fret))
      
    def __repr__(self) -> str:
        return f"FingerPosition(string={self.string}, fret={self.fret})"
      
