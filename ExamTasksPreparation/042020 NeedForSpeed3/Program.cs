using System;
using System.Collections.Generic;
using System.Linq;

namespace _042020_NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                List<string> input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
                cars.Add(Car.AddCar(input));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                List<string> commands = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Drive"))
                {
                    var carName = commands[1];
                    var carFuel = cars.Where(x => x.CarName == carName).Select(x => x.Fuel).ToList();
                    var neededFuel = int.Parse(commands[3]);
                    var addMileage = int.Parse(commands[2]);
                    if (carFuel[0] >= neededFuel)
                    {
                        cars.Where(x => x.CarName == carName).Select(x => x.Mileage += addMileage).ToList();
                        cars.Where(x => x.CarName == carName).Select(x => x.Fuel -= neededFuel).ToList();
                        Console.WriteLine($"{carName} driven for {addMileage} kilometers. {neededFuel} liters of fuel consumed.");
                        var carMileage = cars.Where(x => x.CarName == carName).Select(x => x.Mileage).ToList();
                        if (carMileage[0] >= 100000)
                        {
                            cars.RemoveAll(x => x.CarName == carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (commands.Contains("Refuel"))
                {
                    int addFuel = int.Parse(commands[2]);
                    var currentFuel = cars.Where(x => x.CarName == commands[1]).Select(x => x.Fuel).ToList();
                    if (addFuel + currentFuel[0] <= 75)
                    {
                        cars.Where(x => x.CarName == commands[1]).Select(x => x.Fuel += addFuel).ToList();
                        Console.WriteLine($"{commands[1]} refueled with {addFuel} liters");
                    }
                    else
                    {
                        int maxFuelTank = 75;
                        int diff = maxFuelTank - currentFuel[0];
                        cars.Where(x => x.CarName == commands[1]).Select(x => x.Fuel = maxFuelTank).ToList();
                        Console.WriteLine($"{commands[1]} refueled with {diff} liters");
                    }
                }
                else if (commands.Contains("Revert"))
                {
                    int revertKM = int.Parse(commands[2]);
                    var currentDistance = cars.Where(x => x.CarName == commands[1]).Select(x => x.Mileage).ToList();
                    if (currentDistance[0] - revertKM < 10000)
                    {
                        cars.Where(x => x.CarName == commands[1]).Select(x => x.Mileage = 10000).ToList();
                    }
                    else
                    {
                        cars.Where(x => x.CarName == commands[1]).Select(x => x.Mileage -= revertKM).ToList();
                        Console.WriteLine($"{commands[1]} mileage decreased by {revertKM} kilometers");
                    }
                }
            }

            foreach (var car in cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.CarName))
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    public class Car
    {
        public string CarName { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public static Car AddCar(List<string> cars)
        {
            Car car = new Car();
            car.CarName = cars[0];
            car.Mileage = int.Parse(cars[1]);
            car.Fuel = int.Parse(cars[2]);
            return car;
        }
    }
}
