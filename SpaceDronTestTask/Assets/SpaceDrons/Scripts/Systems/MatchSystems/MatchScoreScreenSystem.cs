namespace Avramov.SpaceDrons
{
    public class MatchScoreScreenSystem : BaseSystem
    {
        private ScreensManager _screensManager;
        private MatchModel _matchModel;

        private MatchScoreScreen _screen;

        public MatchScoreScreenSystem(ScreensManager screensManager, MatchModel matchModel)
        {
            _screensManager = screensManager;
            _matchModel = matchModel;
        }

        protected override void Activated()
        {
            if(_screen == null)
                _screen = _screensManager.GetScreen<MatchScoreScreen>();

            _matchModel.ScoreEvent += UpdateScreen;
            UpdateScreen();
            _screen.gameObject.SetActive(true);
        }

        protected override void Deactivated()
        {
            _matchModel.ScoreEvent -= UpdateScreen;

            _screen.gameObject.SetActive(false);
        }

        private void UpdateScreen(int fraction = 0)
        {
            _screen.SetupScores(_matchModel);
        }
    }
}
