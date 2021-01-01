using System;
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
                Rendszam = "ABC123",
                Evjarat = new DateTime(1987, 5, 6),
                Tipus = "Audi",
                Ar=500000 
            });
            autolist.Add(new Auto
            {
                Rendszam = "AAA000",
                Evjarat = new DateTime(2015,10, 10),
                Tipus = "FORD",
                Ar = 1500000
            });
            autolist.Add(new Auto
            {
                Rendszam = "XYZ123",
                Evjarat = new DateTime(2000, 12, 1),
                Tipus = "Nissan",
                Ar = 100000
            });
        }

        public IEnumerable<Auto> autok() => autolist;
    }
}