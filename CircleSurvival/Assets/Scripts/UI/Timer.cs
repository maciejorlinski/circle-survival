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

    public void Set(float goal, Action callback) {
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
            time += Time.deltaTime;
            if (image != null)
                image.fillAmount = time / goal;
            yield return null;
        }
        callback?.Invoke();
        countdown = null;
    }
}
