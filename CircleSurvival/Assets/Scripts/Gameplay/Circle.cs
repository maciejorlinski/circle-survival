using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Circle : MonoBehaviour, IPointerClickHandler {
    #region Inspector
    public CircleType circleType;
    #endregion

    public event Action<Circle> Died;

    private Timer timer;
    private CircleAnimator animator;
    private CircleCallback onClick;
    private CircleCallback onTimeout;

    private void Awake() {
        timer = GetComponent<Timer>();
        animator = GetComponent<CircleAnimator>();
        animator.FinishedHiding += Die;
    }

    private void Die() {
        Died?.Invoke(this);
        Died = null;
    }

    public void Initialize(float lifeTime, CircleCallback onClick, CircleCallback onTimeout) {
        timer.Set(lifeTime, TimedOut);
        this.onClick = onClick;
        this.onTimeout = onTimeout;
        animator.Show();
    }

    private void TimedOut() {
        onTimeout?.Invoke(this.circleType);
        animator.HideAfterTimeout();
    }

    public void OnPointerClick(PointerEventData eventData) {
        timer.Stop();
        onClick?.Invoke(this.circleType);
        animator.HideAfterClick();
    }
}
