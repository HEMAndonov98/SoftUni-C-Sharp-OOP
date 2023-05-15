namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        new private const int BedCapacity = 6;
        public Apartment()
            : base(BedCapacity)
        {
        }
    }
}

