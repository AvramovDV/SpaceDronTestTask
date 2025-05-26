using UnityEngine;

namespace Avramov.SpaceDrons
{
    [CreateAssetMenu(fileName = "MatchSettingsConfig", menuName = "SpaceDrons/MatchSettingsConfig")]
    public class MatchSettingsConfig : ScriptableObject
    {
        [field: SerializeField] public MatchSettingsData DefaultSettings { get; private set; }
    }
}
