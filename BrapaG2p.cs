using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using OpenUtau.Api;

namespace OpenUtau.Core.G2p {
    public class BrapaG2p : G2pPack {
        private static readonly string[] graphemes = new string[] {
            "", "", "", "", "a", "b", "c", "d", "e", "f", "g",
            "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
            "s", "t", "u", "v", "w", "x", "y", "z", "á", "â",
            "ã","à","ç","é","ê","í","ó","ô","õ","ú","è","ì",
            "ñ","ò","ü","ũ","\'","-",
        };

        private static readonly string[] phonemes = new string[] {
            "", "", "", "", "a", "ae", "an", "ax", "b", "ch", "d", "dj", "e",
            "eh", "en", "f", "g", "h", "hr", "i", "i0", "in", "j", "k", "l", "lh",
            "m", "n", "ng","nh","o","oh","on","p","r","rh","rr","rw","s","sh","t",
            "u","u0","un","v","w","x","y","z",
        };

        private static object lockObj = new object();
        private static Dictionary<string, int> graphemeIndexes;
        private static IG2p dict;
        private static InferenceSession session;
        private static Dictionary<string, string[]> predCache = new Dictionary<string, string[]>();

        public BrapaG2p() {
            lock (lockObj) {
                if (graphemeIndexes == null) {
                    graphemeIndexes = graphemes
                    .Skip(4)
                    .Select((g, i) => Tuple.Create(g, i))
                    .ToDictionary(t => t.Item1, t => t.Item2 + 4);
                    var tuple = LoadPack(DiffSingerBrapaPhonemizer.Resources.g2p_brapa);
                    dict = tuple.Item1;
                    session = tuple.Item2;
                }
            }
            GraphemeIndexes = graphemeIndexes;
            Phonemes = phonemes;
            Dict = dict;
            Session = session;
            PredCache = predCache;
        }
    }
}
