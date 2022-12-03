using System;

namespace SolarRushAmerica
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SolarRush())
                game.Run();
        }
    }
}
