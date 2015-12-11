using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    // The different types of Vhicle
    public enum VehicleType
    {
        TwoWheeler,
        ThreeWheeler,
        FourWheeler
    }

    // Vehicle class
    public class Vehicle
    {
        internal virtual void PrintVehicle()
        {
            Console.WriteLine("This is a Default Wheeler!");
        }
    }

    // Twowheeler vehicle
    public class TwoWheeler : Vehicle
    {
        internal override void PrintVehicle()
        {
            Console.WriteLine("This is a Two Wheeler!");
        }
    }

    // Fourwheeler vehicle
    public class FourWheeler : Vehicle
    {
        internal override void PrintVehicle()
        {
            Console.WriteLine("This is a Four Wheeler!");
        }
    }

    // Invalid vehicle
    internal class InvalidVehicle : Vehicle
    {
        internal override void PrintVehicle()
        {
            Console.WriteLine("This vehicle doesn't exist!");
        }
    }

    // Creator class
    internal class Creator
    {
        internal Vehicle FacrotyMethod(VehicleType type)
        {
            if (type == VehicleType.TwoWheeler)
                return new TwoWheeler();
            else if (type == VehicleType.FourWheeler)
                return new FourWheeler();
            else
                return new InvalidVehicle();
        }
    }
}
