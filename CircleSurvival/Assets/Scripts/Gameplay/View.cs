using System;
using UnityEngine;

namespace Gameplay {
    public class View : MonoBehaviour {
        #region Inspector
        public GameObject hud;
        public ScoreWidget currentScore;
        public GameSummaryView gameSummaryView;
        #endregion

        public void UpdateScore(float score) {
            currentScore.SetScore(score);
        }

        public void DisplayGameSummary(float score, bool newHighScore, Action callback) {
            hud.SetActive(false);
            gameSummaryView.Show(score, newHighScore);
            gameSummaryView.Closed += callback;
        }
    }
}