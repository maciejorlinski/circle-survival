using UnityEngine;

namespace MainMenu {
    public class View : MonoBehaviour {
        #region Inspector
        public ScoreWidget score;
        #endregion

        public void SetHighScore(float value) => score.SetScore(value);
    }
}
