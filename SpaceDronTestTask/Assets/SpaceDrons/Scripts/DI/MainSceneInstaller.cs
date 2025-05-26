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
        }

        private void InstallModels()
        {
            Container.Bind<MatchSettingsModel>().AsSingle();
        }

        private void InstallControllers()
        {
            Container.BindInterfacesAndSelfTo<DIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemsController>().AsSingle();
        }

        private void InstallSceneObjects()
        {
            Container.Bind<ScreensManager>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallSystems()
        {
            Container.BindInterfacesAndSelfTo<InitSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartScreenSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<GameSettingsScreenSystem>().AsSingle();
        }
    }
}
