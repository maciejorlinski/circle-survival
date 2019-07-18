using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveService : ISaveService {
    private const string HIGH_SCORE_KEY = "HighScore";

    public SaveData Load() {
        return new SaveData(PlayerPrefs.GetFloat(HIGH_SCORE_KEY, SaveData.EMPTY_HIGH_SCORE));
    }

    public void Save(SaveData save) {
        PlayerPrefs.SetFloat(HIGH_SCORE_KEY, save.highScore);
        PlayerPrefs.Save();
    }
}
