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
    private CircleCallback onClick;
    private CircleCallback onTimeout;

    private void Awake() {
        timer = GetComponent<Timer>();
    }

    private void Die() {
        Died?.Invoke(this);
        Died = null;
    }

    public void Initialize(float lifeTime, CircleCallback onClick, CircleCallback onTimeout) {
        timer.Set(lifeTime, TimedOut);
        this.onClick = onClick;
        this.onTimeout = onTimeout;
    }

    private void TimedOut() {
        onTimeout?.Invoke(this.circleType);
        Die();
    }

    public void OnPointerClick(PointerEventData eventData) {
        timer.Stop();
        onClick?.Invoke(this.circleType);
        Die();
    }
}
