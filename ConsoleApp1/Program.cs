using System;

namespace ConsoleApp1
{
    class Program
    {

        public static void Main()
        {
            // Abstract factory #1

            AnimalFactory factory1 = new FarmyardFactory();
            Area client1 = new Area(factory1);
            client1.Run();

            // Abstract factory #2

            AnimalFactory factory2 = new OutbackFactory();
            Area client2 = new Area(factory2);
            client2.Run();
            // Wait for user input
            Console.ReadKey();
        }
    }

    abstract class AnimalFactory
    {
        public abstract Bird CreateProductA();
        public abstract Cat CreateProductB();
    }

    class FarmyardFactory : AnimalFactory
    {
        public override Bird CreateProductA()
        {
            return new Chicken();
        }
        public override Cat CreateProductB()
        {
            return new FarmCat();
        }
    }

    class OutbackFactory : AnimalFactory
    {
        public override Bird CreateProductA()
        {
            return new Emu();
        }
        public override Cat CreateProductB()
        {
            return new Lion();
        }
    }

    abstract class Bird
    {
    }

    abstract class Cat
    {
        public abstract void Interact(Bird a);
    }

    class Chicken : Bird
    {
    }

    class FarmCat : Cat
    {
        public override void Interact(Bird a)
        {
            Console.WriteLine(this.GetType().Name +
              " eats " + a.GetType().Name);
        }
    }

    class Emu : Bird
    {
    }


    class Lion : Cat
    {
        public override void Interact(Bird a)
        {
            Console.WriteLine(this.GetType().Name +
              " devours " + a.GetType().Name);
        }
    }


    class Area
    {
        private Bird _abstractProductA;
        private Cat _abstractProductB;
        // Constructor

        public Area(AnimalFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}

