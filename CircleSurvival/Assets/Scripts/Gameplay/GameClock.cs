using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour {
    #region Inspector
    public float timeScale = 1;
    #endregion

    public bool IsRunning { get; private set; }
    public float DeltaTime => IsRunning ? Time.deltaTime * timeScale : 0;

    public void Toggle(bool start) {
        IsRunning = start;
    }
}
