using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWidget : MonoBehaviour {
    #region Inspector
    public string emptyScoreText = "None";
    public string scoreFormat = "{0}h {1}m {2}s";
    public Text score;
    #endregion

    public void SetScore(float value) {
        score.text = value == SaveData.EMPTY_HIGH_SCORE ? emptyScoreText : FormatHighScore(value);
    }

    private string FormatHighScore(float value) {
        var span = TimeSpan.FromSeconds(value);
        return string.Format(scoreFormat, Math.Floor(span.TotalHours), span.Minutes, span.Seconds);
    }
}
