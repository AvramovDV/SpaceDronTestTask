using Cysharp.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Avramov.SpaceDrons
{
    public class DronLogic
    {
        private DronSpawner _dronSpawner;
        private ResourceSpawner _resourceSpawner;
        private MatchSettingsModel _matchSettingsModel;
        private MatchModel _matchModel;

        private DronModel _dronModel;
        private DronView _dronView;
        private Transform _fractionPoint;

        private CancellationTokenSource _currentTaskCTS;
        private int _getResDelayMS = 2000;

        public int FractionId => _dronModel.FractionId;

        public DronLogic(
            DronSpawner dronSpawner,
            ResourceSpawner resourceSpawner,
            MatchSettingsModel matchSettingsModel,
            MatchModel matchModel)
        {
            _dronSpawner = dronSpawner;
            _resourceSpawner = resourceSpawner;
            _matchSettingsModel = matchSettingsModel;
            _matchModel = matchModel;
        }

        public void Init(int fractionId)
        {
            _dronModel = _matchModel.SpawnDron(fractionId);
            _dronSpawner.SpawnDron(_dronModel);
            _dronView = _dronSpawner.GetDron(_dronModel);
            _fractionPoint = _dronSpawner.FracionBases.First(x => x.FractionId == fractionId).Point;
            _matchSettingsModel.DronsSpeed.ChangedEvent += SetupSpeed;
            _dronView.ResourceEvent += OnResource;
            _dronView.FractionBaseEvent += OnFractionBase;
            _resourceSpawner.SpawnEvent += DefineTarget;
            _matchModel.ResourceOcuppiedEvent += DefineTarget;
            SetupSpeed();
        }

        private void SetupSpeed()
        {
            _dronView.Agent.speed = _matchSettingsModel.DronsSpeed.Value;
        }

        private void DefineTarget()
        {
            if (_dronModel.Resource != null)
                return;

            var freeTargets = _resourceSpawner.Resources.Where(x => !x.Model.Occupied);
            ResourceView target = GetNearest(freeTargets);
            if (target != null)
            {
                _dronView.Agent.SetDestination(target.transform.position);
            }
            else
            {
                _dronView.Agent.SetDestination(_dronView.transform.position);
            }
        }

        private async void OnResource(ResourceView resourceView)
        {
            if (_dronModel.Resource != null)
                return;

            if (resourceView.Model.Occupied)
                return;

            resourceView.Model.SetOccupied();
            _dronModel.GetResource(resourceView.Model);
            _matchModel.OccupiedResource();

            _currentTaskCTS = new CancellationTokenSource();
            CancellationToken cancellationToken = _currentTaskCTS.Token;
            await UniTask.Delay(_getResDelayMS, cancellationToken: cancellationToken).SuppressCancellationThrow();

            if(!cancellationToken.IsCancellationRequested)
            {
                _matchModel.RemoveResource(resourceView.Model);
                _dronView.Agent.SetDestination(_fractionPoint.position);
            }

            _currentTaskCTS.Dispose();
            _currentTaskCTS = null;
        }

        private void OnFractionBase(FractionBaseView baseVeiw)
        {
            if(_dronModel.Resource == null)
                return;

            _matchModel.AddResourceToFraction(_dronModel.Resource, _dronModel.FractionId);
            _dronModel.RemoveResource();
            DefineTarget();
        }

        private ResourceView GetNearest(IEnumerable<ResourceView> resources)
        {
            if (resources == null || resources.Count() == 0)
                return null;

            ResourceView nearest = resources.First();
            float minDistance = Vector3.Distance(nearest.transform.position, _dronView.transform.position);
            foreach (var resource in resources)
            {
                float distance = Vector3.Distance(resource.transform.position, _dronView.transform.position);
                if(distance < minDistance)
                {
                    nearest = resource;
                    minDistance = distance;
                }
            }
            return nearest;
        }

        public void Dispose()
        {
            _matchSettingsModel.DronsSpeed.ChangedEvent -= SetupSpeed;
            _dronView.ResourceEvent -= OnResource;
            _dronView.FractionBaseEvent -= OnFractionBase;
            _resourceSpawner.SpawnEvent -= DefineTarget;
            _matchModel.ResourceOcuppiedEvent -= DefineTarget;
            _currentTaskCTS?.Cancel();
            _matchModel.RemoveDron(_dronModel);
            _dronSpawner.RemoveDron(_dronModel);
            _dronModel = null;
            _dronView = null;
        }
    }
}
