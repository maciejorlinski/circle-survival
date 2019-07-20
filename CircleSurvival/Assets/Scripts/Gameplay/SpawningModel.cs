using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningModel {
    public struct CircleData {
        public CircleType circleType;
        public float lifeTime;

        public CircleData(CircleType circleType, float lifeTime) {
            this.circleType = circleType;
            this.lifeTime = lifeTime;
        }
    }

    private GameplayBalanceData balanceData;

    public SpawningModel(GameplayBalanceData balanceData) {
        this.balanceData = balanceData;
    }

    public CircleData GetCircleData(float time) {
        var circleType = GetCircleType(time);
        if (circleType == CircleType.None)
            return new CircleData(circleType, 0);
        return new CircleData(circleType, GetCircleLifetime(time));
    }

    private float GetCircleLifetime(float time) {
        var range = balanceData.GetLifeTimeRangeAtTime(time);
        return Random.Range(range.x, range.y);
    }

    private CircleType GetCircleType(float time) {
        float frequency = balanceData.GetFrequencyAtTime(time);
        bool spawn = Random.value < frequency;
        if (!spawn)
            return CircleType.None;
        if (Random.value < balanceData.blackCircleFrequency)
            return CircleType.Black;
        return CircleType.Green;
    }
}
