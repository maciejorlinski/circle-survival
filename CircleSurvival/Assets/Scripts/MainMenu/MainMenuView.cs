using UnityEngine;

public class MainMenuView : MonoBehaviour {
    #region Inspector
    public ScoreWidget score;
    #endregion

    public void SetHighScore(float value) => score.SetScore(value);
}
