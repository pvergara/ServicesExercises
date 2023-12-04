namespace ServicesExercises
{
    internal class Horse
    {
        public Horse(int position)
        {
            _position = position;
        }

        private static string[] HorseRepresentation { get; } = { "*", "+", "-", "$", "@" };
        private static object _l = new();
        private int X { get; set; }
        private int Xx { get; set; }
        private readonly Random _random = new();
        private int _position;
        private static bool _isRaceFinished = false;

        public void Run()
        {
            var sleepTime = _random.Next(100, 200);
            while (X < 50 && !_isRaceFinished)
            {
                lock (_l)
                {
                    Console.SetCursorPosition(Xx, _position + 20);
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Console.SetCursorPosition(X, _position + 5);
                    Console.WriteLine(HorseRepresentation[_position]);
                }
                this.X += _random.Next(1, 5);
                this.Xx += Thread.CurrentThread.Name.Length + 1;
                Thread.Sleep(sleepTime);
            }

            lock (_l)
            {
                _isRaceFinished = true;
            }

            lock (_l)
            {
                Console.SetCursorPosition(Xx, _position + 20);
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.SetCursorPosition(X, _position + 5);
                Console.WriteLine(HorseRepresentation[_position]);
            }


        }


    }
}
