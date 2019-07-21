using UnityEngine;
using DG.Tweening;
using System;

public class CircleAnimator : MonoBehaviour {
    #region Inspector
    public float showAnimationTime = 0.1f;
    public float timeoutAnimationTime = 0.5f;
    public float clickAnimationTime = 0.1f;
    #endregion

    public event Action FinishedHiding;

    public void Show() {
        transform.localScale = Vector3.zero;
        transform
            .DOScale(Vector3.one, showAnimationTime)
            .SetEase(Ease.OutElastic);
    }

    public void HideAfterTimeout() {
        transform
            .DOScale(Vector3.zero, timeoutAnimationTime)
            .SetEase(Ease.InCubic)
            .OnComplete(HideCompleted);
    }

    public void HideAfterClick() {
        transform
            .DOScale(Vector3.zero, clickAnimationTime)
            .SetEase(Ease.OutCubic)
            .OnComplete(HideCompleted);
    }

    private void HideCompleted() {
        FinishedHiding?.Invoke();
    }
}
