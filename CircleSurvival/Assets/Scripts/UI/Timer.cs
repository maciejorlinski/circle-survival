using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    #region Inspector
    public Image image;
    #endregion

    private float goal;
    private IEnumerator countdown;
    private float time;
    private GameClock gameClock;

    public void Set(float goal, Action callback) {
        if (gameClock == null)
            gameClock = FindObjectOfType<GameClock>();
        this.goal = goal;
        countdown = Countdown(callback);
        StartCoroutine(countdown);
    }

    public void Stop() {
        if (countdown != null) {
            StopCoroutine(countdown);
            countdown = null;
        }
    }

    private IEnumerator Countdown(Action callback) {
        time = 0;
        while (time < goal) {
            time += gameClock.DeltaTime;
            if (image != null)
                image.fillAmount = time / goal;
            yield return null;
        }
        callback?.Invoke();
        countdown = null;
    }
}
