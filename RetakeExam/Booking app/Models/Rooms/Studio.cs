namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        new private const int BedCapacity = 4;
        public Studio()
            :base(BedCapacity)
        {
        }
    }
}

