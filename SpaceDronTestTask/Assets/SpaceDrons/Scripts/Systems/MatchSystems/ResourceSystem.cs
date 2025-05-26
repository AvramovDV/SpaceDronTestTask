using Cysharp.Threading.Tasks;
using System.Threading;

namespace Avramov.SpaceDrons
{
    public class ResourceSystem : BaseSystem
    {
        private MatchModel _match;
        private ResourceSpawner _spawner;
        private MatchSettingsModel _matchSettings;

        private CancellationTokenSource _cancellationTokenSource;

        public ResourceSystem(
            MatchModel match,
            ResourceSpawner spawner,
            MatchSettingsModel matchSettings)
        {
            _match = match;
            _spawner = spawner;
            _matchSettings = matchSettings;
        }

        protected override void Activated()
        {
            _match.ResourceRemovedEvent += OnRemoveResource;
            _cancellationTokenSource = new CancellationTokenSource();
            Run(_cancellationTokenSource.Token).Forget();
        }

        protected override void Deactivated()
        {
            _match.ResourceRemovedEvent -= OnRemoveResource;
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
            _spawner.Claer();
        }

        private void SpawnResource()
        {
            if (_match.Resources.Count >= _matchSettings.ResourcesMaxCount.Value)
                return;

            var resourceModel = _match.SpawnResource();
            _spawner.SpawnResource(resourceModel);
        }

        private void OnRemoveResource(ResourceModel resource)
        {
            _spawner.DestroyResource(resource);
        }

        private async UniTaskVoid Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                SpawnResource();
                int delayMS = (int)(1f / _matchSettings.ResourcesSpawnRate.Value * 1000);
                await UniTask.Delay(delayMS, cancellationToken: token).SuppressCancellationThrow();
            }
        }
    }
}
