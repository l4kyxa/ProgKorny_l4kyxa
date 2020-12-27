using System;
using System.Text.RegularExpressions;

namespace Progkorny.Models
{
    public class Auto
    {
        private string _tipus;
        private DateTime _evjarat;
        private long _ar;
        private string _rendszam;
        public string Tipus
        {
            get { return _tipus; }
            set
            {
                if (value==null)
                {
                    throw new ArgumentException(value + "A tipus nem megfelelő");
                }

                _tipus = value;
            }
        }

        public DateTime Evjarat
        {
            get { return _evjarat; }
            set
            {
                if (value > DateTime.Now )
                {
                    throw new ArgumentException(value + "Az évjárat nem megfelelő");
                }

                _evjarat = value;
            }
        }

        public long Ar
        {
            get { return _ar; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(value + " Az ár nem lehet 0.");
                }

                _ar = value;
            }
        }

        public string Rendszam
        {
            get { return _rendszam; }
            set
            {
                Regex r = new Regex(@"^\w{3}\d{3}$");
                if (!r.Match(value).Success)
                {
                    throw new ArgumentException(value + "A rendszám nem megfelelő");
                }

                _rendszam = value;
            }
        }
    }
}