using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Avramov.SpaceDrons
{
    public class MainSceneMain : MonoBehaviour
    {
        private SystemsController _systemController;
        private List<ISystem> _systems;

        [Inject]
        private void Construct(List<ISystem> systems, SystemsController systemController)
        {
            _systems = systems;
            _systemController = systemController;
        }

        private void Start()
        {
            _systemController.Init(_systems);
            _systemController.Activate<InitSystem>();
        }
    }
}
