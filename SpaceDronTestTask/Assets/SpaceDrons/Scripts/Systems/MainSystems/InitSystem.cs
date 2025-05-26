using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class InitSystem : BaseSystem
    {
        private SystemsController _systemsController;
        private MatchSettingsModel _matchSettingsModel;
        private MatchSettingsConfig _matchSettingsConfig;
        private MatchModel _matchModel;

        public InitSystem(
            SystemsController systemsController,
            MatchSettingsModel matchSettingsModel,
            MatchSettingsConfig matchSettingsConfig,
            MatchModel matchModel)
        {
            _systemsController = systemsController;
            _matchSettingsModel = matchSettingsModel;
            _matchSettingsConfig = matchSettingsConfig;
            _matchModel = matchModel;
        }

        protected override void Activated()
        {
            //TODO: some init, boot and so on...
            _matchModel.Clear();
            _matchSettingsModel.Setup(_matchSettingsConfig.DefaultSettings);
            _systemsController.Activate<StartScreenSystem>();
        }

        protected override void Deactivated()
        {
            
        }
    }
}
