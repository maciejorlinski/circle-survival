using UnityEngine;

[CreateAssetMenu(fileName = "BalanceData", menuName = "Data/Balance Data")]
public class GameplayBalanceData : ScriptableObject {
    public float startingFrequency;
    public float frequencyIncreaseOverTime;
    public float blackCircleFrequency = 0.1f;
    public Vector2 startingLifeTimeRange = new Vector2(2, 4);
    public Vector2 lifeTimeRangeModifierOverTime;

    [ContextMenu("Check game time")]
    public void GameTimeCheck() {
        float timeUntilZeroLifeTime = -startingLifeTimeRange.x / lifeTimeRangeModifierOverTime.x;
        float timeUntilAlwaysSpawn = (1 - startingFrequency) / frequencyIncreaseOverTime;
        float timeUntilRangeInvalid = Mathf.Abs(
            (startingLifeTimeRange.y - startingLifeTimeRange.x) / 
            (lifeTimeRangeModifierOverTime.y - lifeTimeRangeModifierOverTime.x));
        Debug.LogFormat("Zero life time in {0:0.###}s, always spawn in {1:0.###}s. Range invalid in {2:0.###}s.", timeUntilZeroLifeTime, timeUntilAlwaysSpawn, timeUntilRangeInvalid);
    }

    public float GetFrequencyAtTime(float time) => startingFrequency + frequencyIncreaseOverTime * time;
    public Vector2 GetLifeTimeRangeAtTime(float time) => startingLifeTimeRange + lifeTimeRangeModifierOverTime * time;
}
