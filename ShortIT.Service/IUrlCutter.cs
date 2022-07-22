using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortIT.Service
{
    public interface IUrlCutter
    {
        public string Encode(int i);
        public int Decode(string i);
    }
}
