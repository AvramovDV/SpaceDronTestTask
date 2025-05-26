using UnityEngine;
using UnityEngine.EventSystems;

namespace Avramov.SpaceDrons
{
    public class StartScreenSystem : BaseSystem
    {
        private ScreensManager _screensManager;
        private SystemsController _systemsController;

        private StartScreen _screen;

        public StartScreenSystem(ScreensManager screensManager, SystemsController systemsController)
        {
            _screensManager = screensManager;
            _systemsController = systemsController;
        }

        protected override void Activated()
        {
            if(_screen == null)
                _screen = _screensManager.GetScreen<StartScreen>();

            _screen.StartButton.ClickEvent += OnStartClick;

            _screen.gameObject.SetActive(true);
        }

        protected override void Deactivated()
        {
            _screen.StartButton.ClickEvent -= OnStartClick;
            _screen.gameObject.SetActive(false);
        }

        private void OnStartClick(PointerEventData eventData)
        {
            _systemsController.SetupMatchSystems();
        }
    }
}
