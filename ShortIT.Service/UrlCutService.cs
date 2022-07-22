using ShortIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortIT.Service
{
    public class UrlCutService : IUrlCutter
    {
        private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly int Base = Alphabet.Length;
        private readonly Link LastLink;
        //public UrlCutService(Link lastLink)
        //{
        //    LastLink = lastLink;
        //}

        public string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }
            return string.Join(string.Empty, s.Reverse());
        }

        public int Decode(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }
            return i;
        }
    }
}