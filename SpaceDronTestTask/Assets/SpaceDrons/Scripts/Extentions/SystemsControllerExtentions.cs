namespace Avramov.SpaceDrons
{
    public static class SystemsControllerExtentions
    {
        public static void SetupMatchSystems(this SystemsController systemsController)
        {
            systemsController.Deactivate<StartScreenSystem>();
            systemsController.Deactivate<InitSystem>();

            systemsController.Activate<GameSettingsScreenSystem>();
            systemsController.Activate<ResourceSystem>();
            systemsController.Activate<DronsSystem>();
            systemsController.Activate<MatchScoreScreenSystem>();
            systemsController.Activate<ScoreEffectSystem>();
        }

        public static void SetupEnterSystems(this SystemsController systemsController)
        {
            systemsController.Activate<StartScreenSystem>();
            systemsController.Activate<InitSystem>();

            systemsController.Deactivate<GameSettingsScreenSystem>();
            systemsController.Deactivate<ResourceSystem>();
            systemsController.Deactivate<DronsSystem>();
            systemsController.Deactivate<MatchScoreScreenSystem>();
            systemsController.Deactivate<ScoreEffectSystem>();
        }
    }
}
