using UnityEngine;
using Zenject;

namespace Avramov.SpaceDrons
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "SpaceDrons/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private MatchSettingsConfig _settingsConfig;

        public override void InstallBindings()
        {
            Container.Bind<MatchSettingsConfig>().FromInstance(_settingsConfig);
        }
    }
}
