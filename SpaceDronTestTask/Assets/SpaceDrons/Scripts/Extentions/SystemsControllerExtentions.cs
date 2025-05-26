namespace Avramov.SpaceDrons
{
    public static class SystemsControllerExtentions
    {
        public static void SetupMatchSystems(this SystemsController systemsController)
        {
            systemsController.Deactivate<StartScreenSystem>();
            systemsController.Deactivate<InitSystem>();

            systemsController.Activate<GameSettingsScreenSystem>();
        }
    }
}
