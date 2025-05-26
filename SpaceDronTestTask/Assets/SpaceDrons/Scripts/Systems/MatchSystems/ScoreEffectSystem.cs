using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class ScoreEffectSystem : BaseSystem
    {
        private ScoreEffectsFractionConfig _config;
        private DronSpawner _spawner;
        private MatchModel _matchModel;

        public ScoreEffectSystem(ScoreEffectsFractionConfig config, DronSpawner spawner, MatchModel matchModel)
        {
            _config = config;
            _spawner = spawner;
            _matchModel = matchModel;
        }

        protected override void Activated()
        {
            _matchModel.ScoreEvent += OnScore;
        }

        protected override void Deactivated()
        {
            _matchModel.ScoreEvent -= OnScore;
        }

        private void OnScore(int fraction)
        {
            var prefab = _config.GetScoreEffect(fraction);
            var point = _spawner.GetFractionPoint(fraction);
            GameObject.Instantiate(prefab, point.position, prefab.transform.rotation);
        }
    }
}
