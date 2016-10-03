using System;

namespace BinarySearch
{
    public class Car
    {
        private readonly Circle[] _circles;

        private readonly Engine _engine;

        public Car()
        {
            _circles = new Circle[4];
            for (int i = 0; i < 4; i++)
                _circles[i] = new Circle();

            _engine = new Engine(100);

            _engine.OnRun += EngineOnOnRun;
        }

        private void EngineOnOnRun(int speed)
        {
            foreach (Circle circle in _circles)
                circle.Speed = speed;
        }

        public void Go()
        {
            _engine.Run();
        }

        public void Left()
        {
            
        }

        public void Right()
        {
            
        }
    }

    public class Kran: Car
    {
        private Arrow _arrow;

        public Kran()
        {
            _arrow = new Arrow();
        }
    }

    public class Arrow
    {
        public int Lenght { get; set; }
    }

    public class Engine
    {
        public int Power { get; private set; }

        public event Action<int> OnRun;

        public Engine(int power)
        {
            Power = power;
        }

        public void Run()
        {
            OnRun(new Random().Next(10) * Power);
        }
    }

    public class Circle
    {
        public int Speed { get; set; }
    }
}
