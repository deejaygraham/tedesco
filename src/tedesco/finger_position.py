from __future__ import annotations

class FingerPosition:
  
    def __init__(self, string: int, fret: int):
        if string < 1 or string > 6:
            raise ValueError("String must be between 1 and 6")
        if fret < 0 or fret > 24:
            raise ValueError("Fret must be between 0 and 24")

        self.string = string  # 6=low E, 1=high E
        self.fret = fret


    def __eq__(self, other: FingerPosition) -> bool:
        return isinstance(other, FingerPosition) and self.string == other.string and self.fret == other.fret
      
    def __hash__(self):
        return hash((self.string, self.fret))
      
    def __repr__(self) -> str:
        return f"FingerPosition(string={self.string}, fret={self.fret})"
      
