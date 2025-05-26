using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    [CreateAssetMenu(fileName = "ScoreEffectsFractionConfig", menuName = "SpaceDrons/ScoreEffectsFractionConfig")]
    public class ScoreEffectsFractionConfig : ScriptableObject
    {
        [SerializeField] private List<ScoreEffect> _effects;

        public GameObject GetScoreEffect(int fractionId) => _effects.Find(x => x.FractionId == fractionId).Prefab;

        [Serializable]
        public class ScoreEffect
        {
            [field: SerializeField] public int FractionId { get; private set; }
            [field: SerializeField] public GameObject Prefab { get; private set; }
        }
    }
}
