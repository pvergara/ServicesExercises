using System;

namespace ServicesExercises
{
    internal class HorseRaceExercise5
    {
        
        private const int UPPER = 5;
        public static Thread[] threads = new Thread[UPPER];
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("hihihi");
            HorseRace();
            Console.ReadKey();
        }

        public static void HorseRace()
        {
            var sleepTime = _random.Next(100, 200);
            for (int i = 0; i < UPPER; i++)
            {
                Horse horse = new(i);
                var thread = new Thread(horse.Run);
                thread.Name = $"{i}";
                threads[i] = thread;
                
                
            }

            for (int i = 0; i < UPPER; i++)
            {
                threads[i].Start();   
                Thread.Sleep(sleepTime);
            }
        }

        
    }
}
