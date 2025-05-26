using UnityEngine;
using Zenject;

namespace Avramov.SpaceDrons
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "SpaceDrons/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private MatchSettingsConfig _settingsConfig;
        [SerializeField] private ScoreEffectsFractionConfig _scoreEffects;

        public override void InstallBindings()
        {
            Container.Bind<MatchSettingsConfig>().FromInstance(_settingsConfig);
            Container.Bind<ScoreEffectsFractionConfig>().FromInstance(_scoreEffects);
        }
    }
}
