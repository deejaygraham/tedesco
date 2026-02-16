"""
Public API for the tedesco package.

Usage for consumers:
    from tedesco import Note, Interval, Scale
"""

from __future__ import annotations

from .note import Note
from .interval import Interval
from .scale import Scale
from .chord import Chord
from .string import String
from .fingerboard import Fingerboard

try:
    from importlib.metadata import version as _pkg_version
except Exception:  # pragma: no cover
    _pkg_version = None  # type: ignore

__all__ = [
    "Note",
    "Interval",
    "Scale",
    "String",
    "Chord",
    "Fingerboard",
]

try:
    __version__ = _pkg_version("tedesco") if _pkg_version else "0.0.0"
except Exception:  # pragma: no cover
    __version__ = "0.0.0"
