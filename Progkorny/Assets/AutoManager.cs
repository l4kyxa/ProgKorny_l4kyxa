using System;
using System.Collections;
using System.Collections.Generic;
using Progkorny.Models;

namespace Progkorny.Assets
{
    public class AutoManager
    {
        private ICollection<Auto> autolist;

        public AutoManager()
        {
            autolist = new List<Auto>();
            autolist.Add(new Auto
            {
                Tipus = "Audi",
                Ar=500000,
                Evjarat = new DateTime(1987,5,6),
                Rendszam = "ABC123"
            });
            autolist.Add(new Auto
            {
                Tipus = "Ford",
                Ar = 7500000,
                Evjarat = new DateTime(1995, 10, 16),
                Rendszam = "AAA000"
            });
            autolist.Add(new Auto
            {
                Tipus = "Renault",
                Ar = 990000,
                Evjarat = new DateTime(2005, 01, 01),
                Rendszam = "ZZZ999"
            });
        }

        public IEnumerable<Auto> autok() => autolist;
    }
}