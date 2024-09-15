using OpenUtau.Api;
using OpenUtau.Core.G2p;

namespace OpenUtau.Core.DiffSinger
{
    [Phonemizer("DiffSinger BRAPA Phonemizer", "DIFFS BRAPA", language: "PT")]
    public class DiffSingerBRAPAPhonemizer : DiffSingerG2pPhonemizer
    {
        protected override string GetDictionaryName() => "dsdict-brapa.yaml";
        protected override string GetLangCode() => "pt";
        protected override IG2p LoadBaseG2p() => new BrapaG2p();
        protected override string[] GetBaseG2pVowels() => new string[] {
            "a", "ae", "an", "ax", "e", "eh", "en", "i", "i0","in",
            "o", "oh", "on", "u", "u0", "un"
        };

        protected override string[] GetBaseG2pConsonants() => new string[] {
            "b", "ch", "d", "dj", "f", "g", "h", "hr", "j", "k", "l", "lh", "m", "n",
            "ng", "nh", "p", "r", "rh", "rr", "rw", "s", "sh", "t", "v", "w", "x",
            "y","z"
        };
    }
}
