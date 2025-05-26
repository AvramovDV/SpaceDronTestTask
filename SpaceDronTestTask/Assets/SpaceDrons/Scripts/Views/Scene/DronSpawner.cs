using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class DronSpawner : MonoBehaviour
    {
        [SerializeField] private DronView _prefab;
        [SerializeField] private List<FractionBase> _bases;

        private List<DronView> _drons = new List<DronView>();

        public IReadOnlyList<FractionBase> FracionBases => _bases;

        public void SpawnDron(DronModel model)
        {
            Transform point = _bases.Find(x => x.FractionId == model.FractionId).Point;
            DronView view = Instantiate(_prefab, point.position, Quaternion.identity, transform);
            view.Setup(model);
            _drons.Add(view);
        }

        public void RemoveDron(DronModel model)
        {
            var view = GetDron(model);
            _drons.Remove(view);
            Destroy(view.gameObject);
        }

        public DronView GetDron(DronModel model) => _drons.Find(x => x.Model == model);

        public Transform GetFractionPoint(int fraction) => _bases.Find(x => x.FractionId == fraction).Point;

        [Serializable]
        public class FractionBase
        {
            [field: SerializeField] public int FractionId {  get; private set; }
            [field: SerializeField] public Transform Point {  get; private set; }
        }
    }
}
