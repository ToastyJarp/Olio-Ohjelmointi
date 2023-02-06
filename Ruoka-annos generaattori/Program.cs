namespace Ruoka_annos_Generaattori
{
    using TurboReader;
    internal class Program
    {
        public static string[] raakaAineet = Enum.GetNames(typeof(raaka_aine));
        public static string[] lisukkeet = Enum.GetNames(typeof(lisuke));
        public static string[] kastikkeet = Enum.GetNames(typeof(kastike));

        static void Main(string[] args)
        {
            (raaka_aine pääAine, lisuke lisuke, kastike kastike) ateria = KokoaAteria();
            Console.WriteLine($"{ateria.pääAine} ja {ateria.lisuke} {ateria.kastike}-kastikkeella");
        }

        public static (raaka_aine, lisuke, kastike) KokoaAteria()
        {
            string input;
            do
            {
                input = KeyboardInput.ReadString($"Pääraaka-aine ({String.Join(",", raakaAineet)}):");
            } while (!raakaAineet.Contains(input));
            raaka_aine pääAine = (raaka_aine) Enum.Parse(typeof(raaka_aine), input);

            input = "";
            do
            {
                input = KeyboardInput.ReadString($"Pääraaka-aine ({String.Join(",", lisukkeet)})");
            } while (!lisukkeet.Contains(input));
            lisuke lisuke = (lisuke) Enum.Parse(typeof(lisuke), input);

            input = "";
            do
            {
                input = KeyboardInput.ReadString($"Pääraaka-aine ({String.Join(",", kastikkeet)})");
            } while (!kastikkeet.Contains(input));
            kastike kastike = (kastike) Enum.Parse(typeof(kastike), input);

            return (pääAine, lisuke, kastike);

        }
        static string listToString(string[] lista)
        {
            string palautettava = String.Join(",", lista);

            return palautettava;
        }

        public enum raaka_aine {nautaa, kanaa, kasviksia}

        public enum lisuke {perunaa, riisiä, pastaa}

        public enum kastike {pippuri, chili, tomaatti, curry}
    }
}