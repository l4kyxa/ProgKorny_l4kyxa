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
                if (value== null)
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
                Regex r = new Regex(@"^\w{3}\d{3}$");//ASD123
                Regex r1 = new Regex(@"^\w{4}\d{2}$");//CICA00
                Regex r2 = new Regex(@"^\w{1}\d{5}$");//P12345
                Regex r3 = new Regex(@"^\w{2}\d{4}$");//RM1234

                if (!r.Match(value).Success && !r1.Match(value).Success && !r2.Match(value).Success && !r3.Match(value).Success )

                {
                    throw new ArgumentException(value + "A rendszám nem megfelelő");
                }

                _rendszam = value;
            }
        }
    }
}