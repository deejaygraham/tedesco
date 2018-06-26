﻿
namespace Tedesco
{
	public enum ScaleDegree
	{
		First,
		Tonic = First,
		Second, 
		Supertonic = Second,
		Third,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mediant")]
        Mediant = Third,
		Fourth, 
		Subdominant = Fourth,
		Fifth, 
		Dominant = Fifth,
		Sixth,
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Submediant")]
        Submediant = Sixth,
		Seventh,
		Octave,   // 8
        FlatNinth,
        Ninth,
        SharpNinth,
        Eleventh,
        SharpEleventh,
        Thirteen
	}
}
