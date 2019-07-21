using System;
using UnityEngine;
using DG.Tweening;

public class GameplayView : MonoBehaviour {
    #region Inspector
    public GameObject hud;
    public ScoreWidget currentScore;
    public GameSummaryView gameSummaryView;
    #endregion

    private IntroAnimation introAnimation;

    private void Awake() {
        introAnimation = GetComponent<IntroAnimation>();
    }

    public void PlayIntro(TweenCallback callback) {
        hud.SetActive(false);
        introAnimation.Play(callback);
    }

    public void UpdateScore(float score) {
        currentScore.SetScore(score);
    }

    public void DisplayGameSummary(float score, bool newHighScore, Action callback) {
        hud.SetActive(false);
        gameSummaryView.Show(score, newHighScore);
        gameSummaryView.Closed += callback;
    }
}
