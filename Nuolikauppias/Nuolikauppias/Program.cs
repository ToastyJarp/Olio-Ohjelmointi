

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
            public Kärki NuolenKärki { get; set; }

            public Perä NuolenPerä { get; set; }

            public int NuolenVarsi { get; set; }

            public Nuoli()
            {
                NuolenKärki = Kärki.puu;

                NuolenPerä = Perä.lehti;

                NuolenVarsi = 60;
            }

            public Nuoli(Kärki nuolenKärki, Perä nuolenPerä, int nuolenVarsi)
            {
                NuolenKärki = nuolenKärki;
                NuolenPerä = nuolenPerä;
                NuolenVarsi = nuolenVarsi;

                if (NuolenVarsi < 60) NuolenVarsi = 60;
                if (NuolenVarsi > 100) NuolenVarsi = 100;
            }

            public float PalautaHinta()
            {
                float hinta = 0;

                hinta += (int) NuolenKärki;
                hinta += (int) NuolenPerä;

                hinta += (0.05f * NuolenVarsi);

                return hinta;
            }

        }

        enum Kärki { puu = 3, teräs = 5, timantti = 50 }
        
        enum Perä { lehti = 0, kanansulka = 1, kotkansulka = 5 }

    }
}