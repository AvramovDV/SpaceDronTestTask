namespace Avramov.SpaceDrons
{
    public class DronModel
    {
        public int FractionId { get; private set; }

        public ResourceModel Resource { get; private set; }

        public DronModel(int fractionId)
        {
            FractionId = fractionId;
        }

        public void GetResource(ResourceModel resource)
        {
            Resource = resource;
        }

        public void RemoveResource()
        {
            Resource = null;
        }
    }
}
