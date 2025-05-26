namespace Avramov.SpaceDrons
{
    public class ResourceModel
    {
        public int Count { get; private set; } = 1;
        public bool Occupied { get; private set; } = false;

        public void SetOccupied() => Occupied = true;
    }
}
