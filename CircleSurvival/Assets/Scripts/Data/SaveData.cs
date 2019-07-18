using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData {
    public const float EMPTY_HIGH_SCORE = 0;

    public float highScore;

    public SaveData(float highScore) {
        this.highScore = highScore;
    }
}
