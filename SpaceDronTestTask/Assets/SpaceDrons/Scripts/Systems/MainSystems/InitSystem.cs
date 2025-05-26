using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class InitSystem : BaseSystem
    {
        private SystemsController _systemsController;
        private MatchSettingsModel _matchSettingsModel;
        private MatchSettingsConfig _matchSettingsConfig;

        public InitSystem(
            SystemsController systemsController,
            MatchSettingsModel matchSettingsModel,
            MatchSettingsConfig matchSettingsConfig)
        {
            _systemsController = systemsController;
            _matchSettingsModel = matchSettingsModel;
            _matchSettingsConfig = matchSettingsConfig;
        }

        protected override void Activated()
        {
            //TODO: some init, boot and so on...
            _matchSettingsModel.Setup(_matchSettingsConfig.DefaultSettings);
            _systemsController.Activate<StartScreenSystem>();
        }

        protected override void Deactivated()
        {
            
        }
    }
}
