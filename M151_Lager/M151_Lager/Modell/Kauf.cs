using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M151_Lager.Modell
{
    public class Kauf
    {
        public int Id { get; set; }
        public int fk_grafikkarte { get; set; }
        public int fk_kaeufer { get; set; }
    }
}
