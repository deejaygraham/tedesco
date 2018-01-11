﻿using System;
using System.Collections.Generic;

namespace Tedesco
{
    public sealed class IntervalPatternDictionary
    {
        private readonly Dictionary<WellKnownIntervalPattern, string> scaleLookup = new Dictionary<WellKnownIntervalPattern, string>
        {
            { WellKnownIntervalPattern.EightToneSpanish,  "1,2,1,1,1,2,2,2" },
            { WellKnownIntervalPattern.Aeolian,           "2,1,2,2,1,2,2" },
            { WellKnownIntervalPattern.Algerian,          "2,1,2,1,1,1,3,1" },
            { WellKnownIntervalPattern.Arabian,           "2,1,2,1,2,1,2,1" },
            { WellKnownIntervalPattern.Augmented,         "3,1,3,1,3,1" },
            { WellKnownIntervalPattern.Balinese,          "1,2,4,1,4" },
            { WellKnownIntervalPattern.BebopDominant,     "2,2,1,2,2,1,1,1" },
            { WellKnownIntervalPattern.BebopDorian,       "2,1,2,2,2,1,1,1" },
            { WellKnownIntervalPattern.BebopMajor,        "2,2,1,2,1,1,2,1" },
            { WellKnownIntervalPattern.BebopMinor,        "2,1,2,2,1,1,1,2 " },
            { WellKnownIntervalPattern.Blues,             "3,2,1,1,3,2 " },
            { WellKnownIntervalPattern.Byzantine,         "1,3,1,2,1,3,1 " },
            { WellKnownIntervalPattern.Chinese,           "4,2,1,4,1 " },
            { WellKnownIntervalPattern.ChineseMongolian,  "2,2,3,2,3 " },
            { WellKnownIntervalPattern.Chromatic,         "1,1,1,1,1,1,1,1,1,1" },
            { WellKnownIntervalPattern.Diminished,        "2,1,2,1,2,1,2,1 " },
            { WellKnownIntervalPattern.Dominant,          "#2 3,1,1,2,2,1,2 " },
            { WellKnownIntervalPattern.DominantAugmented, "2,2,1,3,1,1,2 " },
            { WellKnownIntervalPattern.DominantSus,       "2,3,2,2,1,2 " },
            { WellKnownIntervalPattern.Dorian,            "2,1,2,2,2,1,2 " },
            { WellKnownIntervalPattern.DoubleHarmonic,    "1,3,1,2,1,3,1 " },
            { WellKnownIntervalPattern.Egyptian,          "2,3,2,3,2 " },
            { WellKnownIntervalPattern.Enigmatic,         "1,3,2,2,2,1,1 " },
            { WellKnownIntervalPattern.EnigmaticMinor,    "1,2,3,1,3,1,1 " },
            { WellKnownIntervalPattern.EthiopianARaray,   "2,2,1,2,2,2,1 " },
            { WellKnownIntervalPattern.EthiopianGeez,     "2,1,2,2,1,2,2 " },
            { WellKnownIntervalPattern.HalfWholeDiminished, "1,2,1,2,1,2,1,2 " },
            { WellKnownIntervalPattern.HarmonicMajor,     "2,2,1,2,1,3,1 " },
            { WellKnownIntervalPattern.HarmonicMinor,     "2,1,2,2,1,3,1 " },
            { WellKnownIntervalPattern.Hawaiian,          "2,1,2,2,2,2,1 " },
            { WellKnownIntervalPattern.Hindu,             "2,2,1,2,1,2,2 " },
            { WellKnownIntervalPattern.Hindustan,         "2,2,1,2,1,2,2 " },
            { WellKnownIntervalPattern.Hirojoshi,         "2,1,4,1,4 " },
            { WellKnownIntervalPattern.HungarianGypsy,    "2,1,3,1,1,2,2 " },
            { WellKnownIntervalPattern.HungarianMajor,    "3,1,2,1,2,1,2 " },
            { WellKnownIntervalPattern.HungarianMinor,    "2,1,3,1,1,3,1 " },
            { WellKnownIntervalPattern.Ionian,            "2,2,1,2,2,2,1 " },
            { WellKnownIntervalPattern.JapaneseA,         "1,4,2,1,4 " },
            { WellKnownIntervalPattern.JapaneseB,         "2,3,2,1,4 " },
            { WellKnownIntervalPattern.JapaneseIchikosucho, "2,2,1,1,1,2,2,1 " },
            { WellKnownIntervalPattern.JapaneseTaishikicho, "2,2,1,1,1,2,1,1,1 " },
            { WellKnownIntervalPattern.Javaneese,         "1,2,2,2,2,1,2 " },
            { WellKnownIntervalPattern.JewishAdonaiMalakh, "1,1,1,2,2,2,1,2 " },
            { WellKnownIntervalPattern.JewishAhabaRabba,  "1,3,1,2,1,2,2 " },
            { WellKnownIntervalPattern.JewishMagenAbot,   "1,2,1,2,2,2,1,1 " },
            { WellKnownIntervalPattern.Kumoi,             "2,1,4,2,3 " },
            { WellKnownIntervalPattern.Locrian,           "1,2,2,1,2,2,2 " },
            { WellKnownIntervalPattern.Lydian,            "2,2,2,1,2,2,1 " },
            { WellKnownIntervalPattern.LydianMinor,       "2,2,2,1,1,2,2 " },
            { WellKnownIntervalPattern.Major,             "2,2,1,2,2,2,1 " },
            { WellKnownIntervalPattern.MajorLocrian,      "2,2,1,1,2,2,2 " },
            { WellKnownIntervalPattern.MajorPentatonic,   "2,2,3,2,3 " },
            { WellKnownIntervalPattern.MelaBhavapriya,    "1,1,3,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaChakravakam,   "1,3,1,2,2,1,2 " },
            { WellKnownIntervalPattern.MelaChalanata,     "3,1,1,2,3,1,1 " },
            { WellKnownIntervalPattern.MelaCharukesi,     "2,2,1,2,1,2,2 " },
            { WellKnownIntervalPattern.MelaChitrambari,   "2,2,2,1,3,1,1 " },
            { WellKnownIntervalPattern.MelaDharmavati,    "2,1,3,1,2,2,1 " },
            { WellKnownIntervalPattern.MelaDhatuvardhani, "3,1,2,1,1,3,1 " },
            { WellKnownIntervalPattern.MelaDhavalambari,  "1,3,2,1,1,1,3 " },
            { WellKnownIntervalPattern.MelaDhenuka,       "1,2,2,2,1,3,1 " },
            { WellKnownIntervalPattern.MelaDhirasankarabharana, "2,2,1,2,2,2,1" },
            { WellKnownIntervalPattern.MelaDivyamani,     "1,2,3,1,3,1,1 " },
            { WellKnownIntervalPattern.MelaGamanasrama,   "1,3,2,1,2,2,1 " },
            { WellKnownIntervalPattern.MelaGanamurti,     "1,1,3,2,1,3,1 " },
            { WellKnownIntervalPattern.MelaGangeyabhusani, "3,1,1,2,1,3,1 " },
            { WellKnownIntervalPattern.MelaGaurimanohari, "2,1,2,2,2,2,1 " },
            { WellKnownIntervalPattern.MelaGavambodhi,    "1,2,3,1,1,1,3 " },
            { WellKnownIntervalPattern.MelaGayakapriya,   "1,3,1,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaHanumattodi,   "1,2,2,2,1,2,2 " },
            { WellKnownIntervalPattern.MelaHarikambhoji,  "2,2,1,2,2,1,2 " },
            { WellKnownIntervalPattern.MelaHatakambari,   "1,3,1,2,3,1,1 " },
            { WellKnownIntervalPattern.MelaHemavati,      "2,1,3,1,2,1,2 " },
            { WellKnownIntervalPattern.MelaJalarnavam,    "1,1,4,1,1,2,2 " },
            { WellKnownIntervalPattern.MelaJhalavarali,   "1,1,4,1,1,3,1 " },
            { WellKnownIntervalPattern.MelaJhankaradhvani, "2,1,2,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaJyotisvarupini, "3,1,2,1,1,2,2 " },
            { WellKnownIntervalPattern.MelaKamavardhani,  "1,3,2,1,1,3,1 " },
            { WellKnownIntervalPattern.MelaKanakangi,     "1,1,3,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaKantamani,     "2,2,2,1,1,1,3 " },
            { WellKnownIntervalPattern.MelaKharaharapriya, "2,1,2,2,2,1,2 " },
            { WellKnownIntervalPattern.MelaKiravani,      "2,1,2,2,1,3,1 " },
            { WellKnownIntervalPattern.MelaKokilapriya,   "1,2,2,2,2,2,1 " },
            { WellKnownIntervalPattern.MelaKosalam,       "3,1,2,1,2,2,1 " },
            { WellKnownIntervalPattern.MelaLatangi,       "2,2,2,1,1,3,1 " },
            { WellKnownIntervalPattern.MelaManavati,      "1,1,3,2,2,2,1 " },
            { WellKnownIntervalPattern.MelaMararanjani,   "2,2,1,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaMayamalavagaula, "1,3,1,2,1,1,3 " },
            { WellKnownIntervalPattern.MelaMechakalyani,  "2,2,2,1,2,2,1 " },
            { WellKnownIntervalPattern.MelaNaganandini,   "2,2,1,2,3,1,1 " },
            { WellKnownIntervalPattern.MelaNamanarayani,  "1,3,2,1,1,2,2 " },
            { WellKnownIntervalPattern.MelaNasikabhusani, "3,1,2,1,2,1,2 " },
            { WellKnownIntervalPattern.MelaNatabhairavi,  "2,1,2,2,1,2,2 " },
            { WellKnownIntervalPattern.MelaNatakapriya,   "1,2,2,2,2,1,2" },
            { WellKnownIntervalPattern.MelaNavanitam,     "1,1,4,1,2,1,2 " },
            { WellKnownIntervalPattern.MelaNitimati,      "2,1,3,1,3,1,1 " },
            { WellKnownIntervalPattern.MelaPavani,        "1,1,4,1,2,2,1 " },
            { WellKnownIntervalPattern.MelaRagavardhani,  "3,1,1,2,1,2,2 " },
            { WellKnownIntervalPattern.MelaRaghupriya,    "1,1,4,1,3,1,1 " },
            { WellKnownIntervalPattern.MelaRamapriya,     "1,3,2,1,2,1,2 " },
            { WellKnownIntervalPattern.MelaRasikapriya,   "3,1,2,1,3,1,1 " },
            { WellKnownIntervalPattern.MelaRatnangi,      "1,1,3,2,1,2,2 " },
            { WellKnownIntervalPattern.MelodicAugmented,  "2,1,2,3,1,2,1 " },
            { WellKnownIntervalPattern.MelodicMinor,      "2,1,2,2,2,2,1 " },
            { WellKnownIntervalPattern.Minor,             "2,1,2,2,1,2,2 " },
            { WellKnownIntervalPattern.MinorPentatonic,   "3,2,2,3,2 " },
            { WellKnownIntervalPattern.Mixolydian,        "2,2,1,2,2,1,2 " },
            { WellKnownIntervalPattern.NaturalMinor,      "2,1,2,2,1,2,2 " },
            { WellKnownIntervalPattern.NeapolitanMajor,   "1,2,2,2,2,2,1 " },
            { WellKnownIntervalPattern.NeapolitanMinor,   "1,2,2,2,1,3,1 " },
            { WellKnownIntervalPattern.Oriental,          "1,3,1,1,3,1,2 " },
            { WellKnownIntervalPattern.Pelog,             "1,2,1,3,1,4 " },
            { WellKnownIntervalPattern.PentatonicMajor,   "2,2,3,2,3 " },
            { WellKnownIntervalPattern.PentatonicMinor,   "3,2,2,3,2 " },
            { WellKnownIntervalPattern.Persian,           "1,3,1,1,2,3,1 " },
            { WellKnownIntervalPattern.Phrygian,          "1,2,2,2,1,2,2 " },
            { WellKnownIntervalPattern.SuperLocrian,      "1,2,1,2,2,2,2 " },
            { WellKnownIntervalPattern.SuperLydianAugmented, "3,2,1,2,2,1,1 " },
            { WellKnownIntervalPattern.ThetaAsavari,      "2,1,2,2,1,2,2 " },
            { WellKnownIntervalPattern.ThetaBhairav,      "1,3,1,2,1,3,1 " },
            { WellKnownIntervalPattern.ThetaBhairavi,     "1,2,2,2,1,2,2 " },
            { WellKnownIntervalPattern.ThetaBilaval,      "2,2,1,2,2,2,1 " },
            { WellKnownIntervalPattern.ThetaKafi,         "2,1,2,2,2,1,2 " },
            { WellKnownIntervalPattern.ThetaKalyan,       "2,2,2,1,2,2,1 " },
            { WellKnownIntervalPattern.ThetaKhamaj,       "2,2,1,2,2,1,2 " },
            { WellKnownIntervalPattern.ThetaMarva,        "1,3,2,1,2,2,1 " },
            { WellKnownIntervalPattern.WholeHalfDiminished, "2,1,2,1,2,1,2,1 " },
            { WellKnownIntervalPattern.WholeTone,         "2,2,2,2,2,2 " }
        };

        public IntervalPattern this[WellKnownIntervalPattern pattern]
        {
            get
            {
                if (!this.scaleLookup.ContainsKey(pattern)) throw new ArgumentOutOfRangeException("scale", "Unknown interval pattern");

                return IntervalPattern.FromString(this.scaleLookup[pattern]);
            }
        }
    }
}
