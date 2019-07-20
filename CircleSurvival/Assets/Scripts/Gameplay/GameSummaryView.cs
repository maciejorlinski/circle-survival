using UnityEngine;

public class GameSummaryView : Prompt {
    #region Inspector
    public ScoreWidget scoreWidget;
    public GameObject newHighScoreInfo;
    #endregion

    public void Show(float score, bool newHighScore) {
        base.Show();
        newHighScoreInfo.SetActive(newHighScore);
        scoreWidget.SetScore(score);
    }
}
