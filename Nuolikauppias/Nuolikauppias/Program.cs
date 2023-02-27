

namespace Nuolikauppias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Minkälainen kärki (puu, teräs vai timantti)?: ");
            string kärkiInput = Console.ReadLine();
            Console.Write("Minkälaiset sulat (lehti, kanansulka vai kotkansulka)?: ");
            string peräInput = Console.ReadLine();
            Console.Write("Nuolen pituus (60-100cm): ");
            int nuolenPituus = int.Parse(Console.ReadLine());

            Kärki nuolenKärki = (Kärki) Enum.Parse(typeof(Kärki), kärkiInput.ToLower());
            Perä nuolenPerä = (Perä) Enum.Parse(typeof(Perä), peräInput.ToLower());

            Nuoli nuoli = new Nuoli(nuolenKärki, nuolenPerä, nuolenPituus);
            float hinta = nuoli.PalautaHinta();
            Console.WriteLine($"Tämän nuolen hinta on {hinta} kultaa.");
            
        }

        class Nuoli
        {
            public Kärki _nuolenKärki;

            public Perä _nuolenPerä;

            public int _nuolenVarsi;

            public Nuoli()
            {
                _nuolenKärki = Kärki.puu;

                _nuolenPerä = Perä.lehti;

                _nuolenVarsi = 60;
            }

            public Nuoli(Kärki nuolenKärki, Perä nuolenPerä, int nuolenVarsi)
            {
                _nuolenKärki = nuolenKärki;
                _nuolenPerä = nuolenPerä;
                _nuolenVarsi = nuolenVarsi;

                if (_nuolenVarsi < 60) _nuolenVarsi = 60;
                if (_nuolenVarsi > 100) _nuolenVarsi = 100;
            }

            public float PalautaHinta()
            {
                float hinta = 0;

                hinta += (int) _nuolenKärki;
                hinta += (int) _nuolenPerä;

                hinta += (0.05f * _nuolenVarsi);

                return hinta;
            }
        }

        enum Kärki { puu = 3, teräs = 5, timantti = 50 }
        
        enum Perä { lehti = 0, kanansulka = 1, kotkansulka = 5 }

    }
}