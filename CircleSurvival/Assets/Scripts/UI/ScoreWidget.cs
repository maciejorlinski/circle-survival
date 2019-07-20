using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWidget : MonoBehaviour {
    #region Inspector
    public string emptyScoreText = "None";
    public Text score;
    #endregion

    public void SetScore(float value) {
        score.text = value == SaveData.EMPTY_HIGH_SCORE ? emptyScoreText : FormatHighScore(value);
    }

    private string FormatHighScore(float value) {
        var span = TimeSpan.FromSeconds(value);
        if (span.TotalMinutes >= 1)
            return string.Format("{0}m {1}s", Math.Floor(span.TotalMinutes), span.Seconds);
        else
            return string.Format("{0}s", Math.Floor(span.TotalSeconds));

    }
}
