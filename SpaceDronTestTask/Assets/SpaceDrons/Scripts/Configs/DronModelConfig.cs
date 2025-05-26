using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    [CreateAssetMenu(fileName = "DronModelConfig", menuName = "SpaceDrons/DronModelConfig")]
    public class DronModelConfig : ScriptableObject
    {
        [SerializeField] private List<DronModel> _drons;

        public GameObject GetDron(int fractionID) => _drons.Find(x => x.FractionId == fractionID).Prefab;

        [Serializable]
        public class DronModel
        {
            [field: SerializeField] public int FractionId { get; private set; }
            [field: SerializeField] public GameObject Prefab { get; private set; }
        }
    }
}
