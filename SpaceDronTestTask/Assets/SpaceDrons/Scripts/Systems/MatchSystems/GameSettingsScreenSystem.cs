using UnityEngine;
using UnityEngine.EventSystems;

namespace Avramov.SpaceDrons
{
    public class GameSettingsScreenSystem : BaseSystem
    {
        private ScreensManager _screensManager;
        private MatchSettingsModel _matchSettingsModel;

        private GameSettingsScreen _screen;

        public GameSettingsScreenSystem(ScreensManager screensManager, MatchSettingsModel matchSettingsModel)
        {
            _screensManager = screensManager;
            _matchSettingsModel = matchSettingsModel;
        }

        protected override void Activated()
        {
            if(_screen == null)
                _screen = _screensManager.GetScreen<GameSettingsScreen>();

            SetupScreen();
            Subscribe();

            _screen.gameObject.SetActive(true);
        }

        protected override void Deactivated()
        {
            Unsubscribe();
            _screen.gameObject.SetActive(false);
        }

        private void Subscribe()
        {
            _screen.DronsCountSlider.onValueChanged.AddListener(OnDronsCountChanged);
            _screen.DronsSpeedSlider.onValueChanged.AddListener(OnDronsSpeedChanged);
            _screen.ResourceGenerationRateInputField.onEndEdit.AddListener(OnResourcesSpawnrateChaged);
            _screen.MaxResourceCountInputField.onEndEdit.AddListener(OnResourcesMaxCountChanged);
            _screen.DronsPathToggle.onValueChanged.AddListener(OnShowDeronsPathsChanged);
            _screen.ExitButton.ClickEvent += Exit;
        }

        private void Unsubscribe()
        {
            _screen.DronsCountSlider.onValueChanged.RemoveListener(OnDronsCountChanged);
            _screen.DronsSpeedSlider.onValueChanged.RemoveListener(OnDronsSpeedChanged);
            _screen.ResourceGenerationRateInputField.onEndEdit.RemoveListener(OnResourcesSpawnrateChaged);
            _screen.MaxResourceCountInputField.onEndEdit.RemoveListener(OnResourcesMaxCountChanged);
            _screen.DronsPathToggle.onValueChanged.RemoveListener(OnShowDeronsPathsChanged);
            _screen.ExitButton.ClickEvent -= Exit;
        }

        private void SetupScreen()
        {
            _screen.DronsCountSlider.value = _matchSettingsModel.DronsCount.Value;
            _screen.DronsCountText.text = _matchSettingsModel.DronsCount.Value.ToString();
            _screen.DronsSpeedSlider.value = _matchSettingsModel.DronsSpeed.Value;
            _screen.DronsSpeedText.text = _matchSettingsModel.DronsSpeed.Value.ToString();
            _screen.ResourceGenerationRateInputField.text = _matchSettingsModel.ResourcesSpawnRate.Value.ToString();
            _screen.MaxResourceCountInputField.text = _matchSettingsModel.ResourcesMaxCount.Value.ToString();
            _screen.DronsPathToggle.isOn = _matchSettingsModel.ShowDronsPaths.Value;
        }

        private void OnDronsCountChanged(float count)
        {
            _matchSettingsModel.DronsCount.Value = (int)count;
            _screen.DronsCountText.text = count.ToString("F0");
        }

        private void OnDronsSpeedChanged(float speed)
        {
            _matchSettingsModel.DronsSpeed.Value = (int)speed;
            _screen.DronsSpeedText.text = speed.ToString("F0");
        }

        private void OnResourcesSpawnrateChaged(string rate)
        {
            float value = float.Parse(rate);
            _matchSettingsModel.ResourcesSpawnRate.Value = value;
        }

        private void OnResourcesMaxCountChanged(string maxCount)
        {
            int value = int.Parse(maxCount);
            _matchSettingsModel.ResourcesMaxCount.Value = value;
        }

        private void OnShowDeronsPathsChanged(bool value)
        {
            _matchSettingsModel.ShowDronsPaths.Value = value;
        }

        private void Exit(PointerEventData data)
        {

        }
    }
}
