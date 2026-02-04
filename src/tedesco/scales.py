# Map canonical scale names to *cumulative* semitone offsets above the root,
# expressed as comma-separated strings.
from .interval import Interval

SCALE_PATTERNS: dict[str, str] = {
    "eighttone_spanish":  "1,2,1,1,1,2,2,2",
    "aeolian":           "2,1,2,2,1,2,2",
    "algerian":          "2,1,2,1,1,1,3,1",
    "arabian":           "2,1,2,1,2,1,2,1",
    "augmented":         "3,1,3,1,3,1",
    "balinese":          "1,2,4,1,4",
    "bebop_dominant":     "2,2,1,2,2,1,1,1",
    "bebop_dorian":       "2,1,2,2,2,1,1,1",
    "bebop_major":        "2,2,1,2,1,1,2,1",
    "bebop_minor":        "2,1,2,2,1,1,1,2",
    "blues":             "3,2,1,1,3,2",
    "byzantine":         "1,3,1,2,1,3,1",
    "chinese":           "4,2,1,4,1",
    "chinese_mongolian":  "2,2,3,2,3",
    "chromatic":         "1,1,1,1,1,1,1,1,1,1",
    "diminished":        "2,1,2,1,2,1,2,1",
    "dominant":          "#2 3,1,1,2,2,1,2",
    "dominant_augmented": "2,2,1,3,1,1,2",
    "dominant_sus":       "2,3,2,2,1,2",
    "dorian":            "2,1,2,2,2,1,2",
    "double_harmonic":    "1,3,1,2,1,3,1",
    "egyptian":          "2,3,2,3,2",
    "enigmatic":         "1,3,2,2,2,1,1",
    "enigmatic_minor":    "1,2,3,1,3,1,1",
    "ethiopian_araray":   "2,2,1,2,2,2,1",
    "ethiopian_geez,     "2,1,2,2,1,2,2",
    "half_whole_diminished": "1,2,1,2,1,2,1,2",
    "harmonic_major":     "2,2,1,2,1,3,1",
    "harmonic_minor":     "2,1,2,2,1,3,1",
    "hawaiian":          "2,1,2,2,2,2,1",
    "hindu":             "2,2,1,2,1,2,2",
    "hindustan":         "2,2,1,2,1,2,2",
    "hirojoshi":         "2,1,4,1,4",
    "hungarian_gypsy":    "2,1,3,1,1,2,2",
    "hungarian_major":    "3,1,2,1,2,1,2",
    "hungarian_minor":    "2,1,3,1,1,3,1",
    "ionian":            "2,2,1,2,2,2,1",
    "japanese_a":         "1,4,2,1,4",
    "japanese_b":         "2,3,2,1,4",
    "japanese_ichikosucho": "2,2,1,1,1,2,2,1",
    "japanese_taishikicho": "2,2,1,1,1,2,1,1,1",
    "javaneese":         "1,2,2,2,2,1,2",
    "jewish_adonaimalakh": "1,1,1,2,2,2,1,2",
    "jewish_ahabarabba":  "1,3,1,2,1,2,2",
    "jewish_magenabot":   "1,2,1,2,2,2,1,1",
    "kumoi":             "2,1,4,2,3",
    "locrian":           "1,2,2,1,2,2,2",
    "lydian":            "2,2,2,1,2,2,1",
    "lydian_minor":       "2,2,2,1,1,2,2",
    "major":             "2,2,1,2,2,2,1",
    "major_locrian":      "2,2,1,1,2,2,2",
    "major_pentatonic":   "2,2,3,2,3",
    "melodic_augmented":  "2,1,2,3,1,2,1",
    "melodic_minor":      "2,1,2,2,2,2,1",
    "minor":             "2,1,2,2,1,2,2",
    "minor_pentatonic":   "3,2,2,3,2",
    "mixolydian":        "2,2,1,2,2,1,2",
    "natural_minor":      "2,1,2,2,1,2,2",
    "neapolitan_major":   "1,2,2,2,2,2,1",
    "neapolitan_minor":   "1,2,2,2,1,3,1",
    "oriental":          "1,3,1,1,3,1,2",
    "pelog":             "1,2,1,3,1,4",
    "pentatonic_major":   "2,2,3,2,3",
    "pentatonic_minor":   "3,2,2,3,2",
    "persian":           "1,3,1,1,2,3,1",
    "phrygian":          "1,2,2,2,1,2,2",
    "super_locrian":      "1,2,1,2,2,2,2",
    "super_lydian_augmented": "3,2,1,2,2,1,1",
    "theta_asavari":      "2,1,2,2,1,2,2",
    "theta_bhairav":      "1,3,1,2,1,3,1",
    "theta_bhairavi":     "1,2,2,2,1,2,2",
    "theta_bilaval":     "2,2,1,2,2,2,1",
    "theta_kafi":         "2,1,2,2,2,1,2",
    "theta_kalyan":       "2,2,2,1,2,2,1",
    "theta_khamaj":       "2,2,1,2,2,1,2",
    "theta_marva":        "1,3,2,1,2,2,1",
    "whole_half_diminished": "2,1,2,1,2,1,2,1",
    "wholetone":         "2,2,2,2,2,2"
}

def get_scale_intervals(name: str) -> list[Interval]:
    """
    Return a list of Interval objects for the named scale.

    Parameters
    ----------
    name : str
        Scale name (case-insensitive). e.g., "major", "dorian", "minor_pentatonic".

    Returns
    -------
    list[Interval]
    """
    key = name.strip().lower()
    try:
        csv = SCALE_PATTERNS[key]
    except KeyError as exc:
        available = ", ".join(sorted(SCALE_PATTERNS))
        raise KeyError(f"Unknown scale '{name}'. Available: {available}") from exc
    return Interval.list_from_string(csv, cumulative=False)
