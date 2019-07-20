using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Circle : MonoBehaviour, IPointerClickHandler {
    private Timer timer;
    private Action onClick;

    private void Awake() {
        timer = GetComponent<Timer>();
    }

    public void Initialize(float lifeTime, Action onClick, Action onTimeout) {
        timer.Set(lifeTime, onTimeout);
        this.onClick = onClick;
    }

    public void OnPointerClick(PointerEventData eventData) {
        timer.Stop();
        onClick?.Invoke();
    }
}
