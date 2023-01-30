namespace Ovi
{
    internal class Program
    {
        static void Main(string[] args)
        {


            OviTilanne oviNyt = OviTilanne.Lukossa;

            while (true)
            {
                Console.WriteLine($"Ovi on {oviNyt}. Mitä haluat tehdä?");
                switch (oviNyt)
                {
                    case OviTilanne.Auki:
                        oviNyt = oviInteraction(oviNyt, new string[] {"sulje"});
                        break;
                    case OviTilanne.Kiinni:
                        oviNyt = oviInteraction(oviNyt, new string[] {"avaa", "lukitse"});
                        break;
                    case OviTilanne.Lukossa:
                        oviNyt = oviInteraction(oviNyt, new string[] { "poista lukko" });
                        break;
                }
            }
        }

        static OviTilanne oviInteraction(OviTilanne oviNyt, string[] hyväksyttävät)
        {
            string input = Console.ReadLine();
            if (input != null)
            {
                if (hyväksyttävät.Contains(input.ToLower()))
                {
                    switch (input.ToLower())
                    {
                        case "avaa":
                            oviNyt = OviTilanne.Auki;
                            break;
                        case "sulje":
                            oviNyt = OviTilanne.Kiinni;
                            break;
                        case "lukitse":
                            oviNyt = OviTilanne.Lukossa;
                            break;
                        case "poista lukko":
                            oviNyt = OviTilanne.Kiinni;
                            break;
                    }
                }
            }
            return oviNyt;
            
        }

        enum OviTilanne {Auki, Kiinni, Lukossa}
    }
}