using System;
using UnityEngine;
using UnityEngine.AI;

namespace Avramov.SpaceDrons
{
    public class DronView : MonoBehaviour
    {
        [SerializeField] private DronModelConfig _dronsConfig;

        [field: SerializeField] public NavMeshAgent Agent { get; private set; }

        private GameObject _view;

        public DronModel Model { get; private set; }

        public event Action<ResourceView> ResourceEvent;
        public event Action<FractionBaseView> FractionBaseEvent;

        private void OnTriggerEnter(Collider other)
        {
            CheckTrigger<ResourceView>(other, (view) => ResourceEvent?.Invoke(view));
            CheckTrigger<FractionBaseView>(other, (view) => FractionBaseEvent?.Invoke(view));
        }

        private void OnDestroy()
        {
            if(_view != null)
                Destroy(_view);
        }

        public void Setup(DronModel model)
        {
            Model = model;

            if (_view != null)
                Destroy(_view);

            _view = Instantiate(_dronsConfig.GetDron(model.FractionId), transform);
        }

        private void CheckTrigger<T>(Collider other, Action<T> callback)
        {
            T view = other.GetComponent<T>();
            if(view != null)
                callback(view);
        }
    }
}
