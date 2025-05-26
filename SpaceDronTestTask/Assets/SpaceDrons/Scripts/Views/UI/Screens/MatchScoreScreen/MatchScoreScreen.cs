using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Avramov.SpaceDrons
{
    public class MatchScoreScreen : BaseScreen
    {
        [SerializeField] private List<FractionScore> _fractionScores;

        public void SetupScores(MatchModel matchModel)
        {
            foreach (var item in _fractionScores)
            {
                int score = matchModel.GetScoreForFraction(item.FractionId);
                item.ScoreText.text = score.ToString();
            }
        }


        [Serializable]
        public class FractionScore
        {
            [field: SerializeField] public int FractionId { get; private set; }
            [field: SerializeField] public TMP_Text ScoreText { get; private set; }
        }
    }
}
