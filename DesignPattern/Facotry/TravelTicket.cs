using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation
{
    /// <summary>
    /// In travel site, we can book train ticket as well bus tickets and flight ticket. 
    /// In this case user can give his travel type as ‘bus’, ‘train’ or ‘flight’.
    /// Here we have an abstract class ‘AnyTravel’ with a static member function ‘GetObject’ 
    /// which depending on user’s travel type, will create & return object of ‘BusTravel’ or ‘ TrainTravel’. 
    /// ‘BusTravel’ or ‘ TrainTravel’ have common functions like passenger name, Origin, destinationparameters.
    /// </summary>
    enum TicketType
    {
        Bus,
        Train,
        Flight,
        Invalid
    }

    public interface ITicket
    {
        void PrintTicket();
    }

    public class BusTicket : ITicket
    {
        public void PrintTicket()
        {
            Console.WriteLine("Here's your Bus Ticket");
        }
    }

    public class TrainTicket : ITicket
    {
        public void PrintTicket()
        {
            Console.WriteLine("Here's your Train Ticket");
        }
    }

    public class PlaneTicket : ITicket
    {
        public void PrintTicket()
        {
            Console.WriteLine("Here's your Plane Ticket");
        }
    }

    public class InvalidTicketType : ITicket
    {
        public void PrintTicket()
        {
            Console.WriteLine("No ticket for you. Sorry.");
        }
    }

    abstract class TicketCreator
    {
        public static ITicket FactoryMethod(TicketType type)
        {
            switch (type)
            {
                case TicketType.Bus:
                    return new BusTicket();
                case TicketType.Train:
                    return new TrainTicket();
                case TicketType.Flight:
                    return new PlaneTicket();
                default:
                    return new InvalidTicketType();
            }
        }
    }
}
