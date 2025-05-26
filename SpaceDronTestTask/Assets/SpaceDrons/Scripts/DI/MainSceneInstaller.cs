using Zenject;

namespace Avramov.SpaceDrons
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallModels();
            InstallControllers();
            InstallSceneObjects();
            InstallSystems();
            InstallDynamics();
        }

        private void InstallModels()
        {
            Container.Bind<MatchSettingsModel>().AsSingle();
            Container.Bind<MatchModel>().AsSingle();
        }

        private void InstallControllers()
        {
            Container.BindInterfacesAndSelfTo<DIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemsController>().AsSingle();
        }

        private void InstallSceneObjects()
        {
            Container.Bind<ScreensManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ResourceSpawner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<DronSpawner>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallSystems()
        {
            Container.BindInterfacesAndSelfTo<InitSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartScreenSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameSettingsScreenSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourceSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<DronsSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MatchScoreScreenSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreEffectSystem>().AsSingle();
        }

        private void InstallDynamics()
        {
            Container.Bind<DronLogic>().AsTransient();
        }
    }
}
