using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class SummaryAnimation : MonoBehaviour {
    #region Inspector
    public ScoreWidget scoreWidget;
    public Text newHighScore;
    public Button continueButton;
    public float showScoreSpeed = 30;
    public Vector3 newHighScoreStartScale = Vector3.one * 4;
    public float showNewHighScoreDuration = 1;
    #endregion

    private float displayedScore;

    public void Play(float score, bool newHighScore) {
        continueButton.interactable = false;
        var tween = DOTween.To(GetDisplayedScore, DisplayScore, score, score / showScoreSpeed)
            .SetEase(Ease.InCubic);
        if (newHighScore)
            tween.OnComplete(ShowNewHighScore);
        else
            tween.OnComplete(FinishAnimation);
    }

    private void ShowNewHighScore() {
        newHighScore.gameObject.SetActive(true);
        newHighScore.transform.localScale = newHighScoreStartScale;
        newHighScore.transform
            .DOScale(Vector3.one, showNewHighScoreDuration)
            .SetEase(Ease.InCubic)
            .OnComplete(FinishAnimation);
        newHighScore
            .DOFade(1, showNewHighScoreDuration)
            .SetEase(Ease.InCubic);
    }

    private float GetDisplayedScore() => displayedScore;

    private void DisplayScore(float score) {
        displayedScore = score;
        scoreWidget.SetScore(score);
    }

    private void FinishAnimation() {
        continueButton.interactable = true;
    }
}
