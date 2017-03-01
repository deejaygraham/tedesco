using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedesco
{
	public class ScaleDictionary
	{
		private Dictionary<WellKnownScale, string> scaleLookup = new Dictionary<WellKnownScale, string>
			{
				{ WellKnownScale.EightToneSpanish,	"1,2,1,1,1,2,2,2" },
				{ WellKnownScale.Aeolian,			"2,1,2,2,1,2,2" },
				{ WellKnownScale.Algerian,			"2,1,2,1,1,1,3,1" },
				{ WellKnownScale.Arabian,			"2,1,2,1,2,1,2,1" },
				{ WellKnownScale.Augmented,			"3,1,3,1,3,1" },
				{ WellKnownScale.Balinese,			"1,2,4,1,4" },
				{ WellKnownScale.BebopDominant,		"2,2,1,2,2,1,1,1" },
				{ WellKnownScale.BebopDorian,		"2,1,2,2,2,1,1,1" },
				{ WellKnownScale.BebopMajor,		"2,2,1,2,1,1,2,1" },
				{ WellKnownScale.BebopMinor,		"2,1,2,2,1,1,1,2 " },
				{ WellKnownScale.Blues,				"3,2,1,1,3,2 " },
				{ WellKnownScale.Byzantine,			"1,3,1,2,1,3,1 " },
				{ WellKnownScale.Chinese,			"4,2,1,4,1 " },
				{ WellKnownScale.ChineseMongolian,	"2,2,3,2,3 " },
				{ WellKnownScale.Chromatic,			"1,1,1,1,1,1,1,1,1,1" },
				{ WellKnownScale.Diminished,		"2,1,2,1,2,1,2,1 " },
				{ WellKnownScale.Dominant,			"#2 3,1,1,2,2,1,2 " },
				{ WellKnownScale.DominantAugmented, "2,2,1,3,1,1,2 " },
				{ WellKnownScale.DominantSus,		"2,3,2,2,1,2 " },
				{ WellKnownScale.Dorian,			"2,1,2,2,2,1,2 " },
				{ WellKnownScale.DoubleHarmonic,	"1,3,1,2,1,3,1 " },
				{ WellKnownScale.Egyptian,			"2,3,2,3,2 " },
				{ WellKnownScale.Enigmatic,			"1,3,2,2,2,1,1 " },
				{ WellKnownScale.EnigmaticMinor,	"1,2,3,1,3,1,1 " },
				{ WellKnownScale.EthiopianARaray,	"2,2,1,2,2,2,1 " },
				{ WellKnownScale.EthiopianGeez,		"2,1,2,2,1,2,2 " },
				{ WellKnownScale.HalfWholeDiminished, "1,2,1,2,1,2,1,2 " },
				{ WellKnownScale.HarmonicMajor,		"2,2,1,2,1,3,1 " },
				{ WellKnownScale.HarmonicMinor,		"2,1,2,2,1,3,1 " },
				{ WellKnownScale.Hawaiian,			"2,1,2,2,2,2,1 " },
				{ WellKnownScale.Hindu,				"2,2,1,2,1,2,2 " },
				{ WellKnownScale.Hindustan,			"2,2,1,2,1,2,2 " },
				{ WellKnownScale.Hirojoshi,			"2,1,4,1,4 " },
				{ WellKnownScale.HungarianGypsy,	"2,1,3,1,1,2,2 " },
				{ WellKnownScale.HungarianMajor,	"3,1,2,1,2,1,2 " },
				{ WellKnownScale.HungarianMinor,	"2,1,3,1,1,3,1 " },
				{ WellKnownScale.Ionian,			"2,2,1,2,2,2,1 " },
				{ WellKnownScale.JapaneseA,			"1,4,2,1,4 " },
				{ WellKnownScale.JapaneseB,			"2,3,2,1,4 " },
				{ WellKnownScale.JapaneseIchikosucho, "2,2,1,1,1,2,2,1 " },
				{ WellKnownScale.JapaneseTaishikicho, "2,2,1,1,1,2,1,1,1 " },
				{ WellKnownScale.Javaneese,			"1,2,2,2,2,1,2 " },
				{ WellKnownScale.JewishAdonaiMalakh, "1,1,1,2,2,2,1,2 " },
				{ WellKnownScale.JewishAhabaRabba,	"1,3,1,2,1,2,2 " },
				{ WellKnownScale.JewishMagenAbot,	"1,2,1,2,2,2,1,1 " },
				{ WellKnownScale.Kumoi,				"2,1,4,2,3 " },
				{ WellKnownScale.Locrian,			"1,2,2,1,2,2,2 " },
				{ WellKnownScale.Lydian,			"2,2,2,1,2,2,1 " },
				{ WellKnownScale.LydianMinor,		"2,2,2,1,1,2,2 " },
				{ WellKnownScale.Major,				"2,2,1,2,2,2,1 " },
				{ WellKnownScale.MajorLocrian,		"2,2,1,1,2,2,2 " },
				{ WellKnownScale.MajorPentatonic,	"2,2,3,2,3 " },
				{ WellKnownScale.MelaBhavapriya,	"1,1,3,2,1,1,3 " },
				{ WellKnownScale.MelaChakravakam,	"1,3,1,2,2,1,2 " },
				{ WellKnownScale.MelaChalanata,		"3,1,1,2,3,1,1 " },
				{ WellKnownScale.MelaCharukesi,		"2,2,1,2,1,2,2 " },
				{ WellKnownScale.MelaChitrambari,	"2,2,2,1,3,1,1 " },
				{ WellKnownScale.MelaDharmavati,	"2,1,3,1,2,2,1 " },
				{ WellKnownScale.MelaDhatuvardhani,	"3,1,2,1,1,3,1 " },
				{ WellKnownScale.MelaDhavalambari,	"1,3,2,1,1,1,3 " },
				{ WellKnownScale.MelaDhenuka,		"1,2,2,2,1,3,1 " },
				{ WellKnownScale.MelaDhirasankarabharana, "2,2,1,2,2,2,1" },
				{ WellKnownScale.MelaDivyamani,		"1,2,3,1,3,1,1 " },
				{ WellKnownScale.MelaGamanasrama,	"1,3,2,1,2,2,1 " },
				{ WellKnownScale.MelaGanamurti,		"1,1,3,2,1,3,1 " },
				{ WellKnownScale.MelaGangeyabhusani, "3,1,1,2,1,3,1 " },
				{ WellKnownScale.MelaGaurimanohari, "2,1,2,2,2,2,1 " },
				{ WellKnownScale.MelaGavambodhi,	"1,2,3,1,1,1,3 " },
				{ WellKnownScale.MelaGayakapriya,	"1,3,1,2,1,1,3 " },
				{ WellKnownScale.MelaHanumattodi,	"1,2,2,2,1,2,2 " },
				{ WellKnownScale.MelaHarikambhoji,	"2,2,1,2,2,1,2 " },
				{ WellKnownScale.MelaHatakambari,	"1,3,1,2,3,1,1 " },
				{ WellKnownScale.MelaHemavati,		"2,1,3,1,2,1,2 " },
				{ WellKnownScale.MelaJalarnavam,	"1,1,4,1,1,2,2 " },
				{ WellKnownScale.MelaJhalavarali,	"1,1,4,1,1,3,1 " },
				{ WellKnownScale.MelaJhankaradhvani, "2,1,2,2,1,1,3 " },
				{ WellKnownScale.MelaJyotisvarupini, "3,1,2,1,1,2,2 " },
				{ WellKnownScale.MelaKamavardhani,	"1,3,2,1,1,3,1 " },
				{ WellKnownScale.MelaKanakangi,		"1,1,3,2,1,1,3 " },
				{ WellKnownScale.MelaKantamani,		"2,2,2,1,1,1,3 " },
				{ WellKnownScale.MelaKharaharapriya, "2,1,2,2,2,1,2 " },
				{ WellKnownScale.MelaKiravani,		"2,1,2,2,1,3,1 " },
				{ WellKnownScale.MelaKokilapriya,	"1,2,2,2,2,2,1 " },
				{ WellKnownScale.MelaKosalam,		"3,1,2,1,2,2,1 " },
				{ WellKnownScale.MelaLatangi,		"2,2,2,1,1,3,1 " },
				{ WellKnownScale.MelaManavati,		"1,1,3,2,2,2,1 " },
				{ WellKnownScale.MelaMararanjani,	"2,2,1,2,1,1,3 " },
				{ WellKnownScale.MelaMayamalavagaula, "1,3,1,2,1,1,3 " },
				{ WellKnownScale.MelaMechakalyani,	"2,2,2,1,2,2,1 " },
				{ WellKnownScale.MelaNaganandini,	"2,2,1,2,3,1,1 " },
				{ WellKnownScale.MelaNamanarayani,	"1,3,2,1,1,2,2 " },
				{ WellKnownScale.MelaNasikabhusani, "3,1,2,1,2,1,2 " },
				{ WellKnownScale.MelaNatabhairavi,	"2,1,2,2,1,2,2 " },
				{ WellKnownScale.MelaNatakapriya,	"1,2,2,2,2,1,2" },
				{ WellKnownScale.MelaNavanitam,		"1,1,4,1,2,1,2 " },
				{ WellKnownScale.MelaNitimati,		"2,1,3,1,3,1,1 " },
				{ WellKnownScale.MelaPavani,		"1,1,4,1,2,2,1 " },
				{ WellKnownScale.MelaRagavardhani,	"3,1,1,2,1,2,2 " },
				{ WellKnownScale.MelaRaghupriya,	"1,1,4,1,3,1,1 " },
				{ WellKnownScale.MelaRamapriya,		"1,3,2,1,2,1,2 " },
				{ WellKnownScale.MelaRasikapriya,	"3,1,2,1,3,1,1 " },
				{ WellKnownScale.MelaRatnangi,		"1,1,3,2,1,2,2 " },
				{ WellKnownScale.MelodicAugmented,	"2,1,2,3,1,2,1 " },
				{ WellKnownScale.MelodicMinor,		"2,1,2,2,2,2,1 " },
				{ WellKnownScale.Minor,				"2,1,2,2,1,2,2 " },
				{ WellKnownScale.MinorPentatonic,	"3,2,2,3,2 " },
				{ WellKnownScale.Mixolydian,		"2,2,1,2,2,1,2 " },
				{ WellKnownScale.NaturalMinor,		"2,1,2,2,1,2,2 " },
				{ WellKnownScale.NeapolitanMajor,	"1,2,2,2,2,2,1 " },
				{ WellKnownScale.NeapolitanMinor,	"1,2,2,2,1,3,1 " },
				{ WellKnownScale.Oriental,			"1,3,1,1,3,1,2 " },
				{ WellKnownScale.Pelog,				"1,2,1,3,1,4 " },
				{ WellKnownScale.PentatonicMajor,	"2,2,3,2,3 " },
				{ WellKnownScale.PentatonicMinor,	"3,2,2,3,2 " },
				{ WellKnownScale.Persian,			"1,3,1,1,2,3,1 " },
				{ WellKnownScale.Phrygian,			"1,2,2,2,1,2,2 " },
				{ WellKnownScale.SuperLocrian,		"1,2,1,2,2,2,2 " },
				{ WellKnownScale.SuperLydianAugmented, "3,2,1,2,2,1,1 " },
				{ WellKnownScale.ThetaAsavari,		"2,1,2,2,1,2,2 " },
				{ WellKnownScale.ThetaBhairav,		"1,3,1,2,1,3,1 " },
				{ WellKnownScale.ThetaBhairavi,		"1,2,2,2,1,2,2 " },
				{ WellKnownScale.ThetaBilaval,		"2,2,1,2,2,2,1 " },
				{ WellKnownScale.ThetaKafi,			"2,1,2,2,2,1,2 " },
				{ WellKnownScale.ThetaKalyan,		"2,2,2,1,2,2,1 " },
				{ WellKnownScale.ThetaKhamaj,		"2,2,1,2,2,1,2 " },
				{ WellKnownScale.ThetaMarva,		"1,3,2,1,2,2,1 " },
				{ WellKnownScale.WholeHalfDiminished, "2,1,2,1,2,1,2,1 " },
				{ WellKnownScale.WholeTone,			"2,2,2,2,2,2 " }
			};

		public IntervalPattern this[WellKnownScale scale]
		{
			get
			{
				if (!this.scaleLookup.ContainsKey(scale))
				{
					throw new ArgumentOutOfRangeException();
				}

				string intervalSequence = this.scaleLookup[scale];

				return this.Build(intervalSequence);
			}
		}

		public Scale Build(Pitch root, WellKnownScale scale)
		{
			if (!this.scaleLookup.ContainsKey(scale))
			{
				throw new ArgumentOutOfRangeException();
			}

			string intervalSequence = this.scaleLookup[scale];

			return new Scale(root, this.Build(intervalSequence));
		}

		private IntervalPattern Build(string pattern)
		{
			var ip = new IntervalPattern();

			string[] words = pattern.Split(new char[] { ',' });

			foreach (string word in words)
			{
				if (!string.IsNullOrEmpty(word))
				{
					int value = Convert.ToInt32(word.Trim());

					if (value > 0)
					{
						ip.Add(new Interval(value));
					}
				}
			}

			return ip;
		}
	}
}
