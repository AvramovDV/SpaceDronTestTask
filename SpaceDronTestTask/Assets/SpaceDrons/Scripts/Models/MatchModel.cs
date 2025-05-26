using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class MatchModel
    {
        private List<ResourceModel> _resources = new List<ResourceModel>();
        private List<DronModel> _drons = new List<DronModel>();
        private Dictionary<int, int> _fractionsScores = new Dictionary<int, int>();

        public IReadOnlyList<ResourceModel> Resources => _resources;
        public IReadOnlyList<DronModel> Drons => _drons;

        public event Action<ResourceModel> ResourceRemovedEvent;
        public event Action ResourceOcuppiedEvent;
        public event Action<int> ScoreEvent;

        public ResourceModel SpawnResource()
        {
            ResourceModel res = new ResourceModel();
            _resources.Add(res);
            return res;
        }

        public void RemoveResource(ResourceModel resource)
        {
            _resources.Remove(resource);
            ResourceRemovedEvent?.Invoke(resource);
        }

        public DronModel SpawnDron(int fractionId)
        {
            DronModel dron = new DronModel(fractionId);
            _drons.Add(dron);
            return dron;
        }

        public void RemoveDron(DronModel dron)
        {
            _drons.Remove(dron);
        }

        public void AddResourceToFraction(ResourceModel resource, int fraction)
        {
            if(!_fractionsScores.ContainsKey(fraction))
                _fractionsScores.Add(fraction, 0);

            _fractionsScores[fraction] += resource.Count;
            ScoreEvent?.Invoke(fraction);
        }

        public void OccupiedResource() => ResourceOcuppiedEvent?.Invoke();

        public int GetScoreForFraction(int fraction)
        {
            if (!_fractionsScores.ContainsKey(fraction))
                _fractionsScores.Add(fraction, 0);

            return _fractionsScores[fraction];
        }

        public void Clear()
        {
            _resources.Clear();
            _drons.Clear();
            _fractionsScores.Clear();
        }
    }
}
