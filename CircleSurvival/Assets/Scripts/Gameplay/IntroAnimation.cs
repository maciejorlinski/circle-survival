using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IntroAnimation : MonoBehaviour {
    #region Inspector
    public Text introText;
    public Vector3 startScale = Vector3.one * 3;
    public float animationDuration = 2;
    #endregion

    public void Play(TweenCallback callback) {
        ShowText("Ready?", () => 
        ShowText("Go!", callback));
    }

    private void ShowText(string text, TweenCallback callback) {
        ResetIntroText(text);
        introText.transform
            .DOScale(Vector3.one, animationDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(HideIntroText + callback);
        introText.DOFade(1, animationDuration * 0.9f)
            .SetEase(Ease.OutCubic);
    }

    private void ResetIntroText(string text) {
        introText.gameObject.SetActive(true);
        introText.text = text;
        introText.transform.localScale = startScale;
        var color = introText.color;
        color.a = 0;
        introText.color = color;
    }

    private void HideIntroText() {
        introText.gameObject.SetActive(false);
    }
}
