using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class ResourceView : MonoBehaviour
    {
        public ResourceModel Model { get; private set; }

        public void Setup(ResourceModel model)
        {
            Model = model;
        }
    }
}
