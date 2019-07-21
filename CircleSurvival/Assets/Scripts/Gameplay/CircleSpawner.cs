using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour {
    #region Inspector
    public GameplayBalanceData balanceData;
    public ObjectPool greenCirclesPool;
    public ObjectPool blackCirclesPool;
    public GameClock gameClock;
    #endregion

    private const int MAX_ACTIVE_CIRCLES = 35;

    public bool CanSpawnCircle => activeCircles < MAX_ACTIVE_CIRCLES;

    private float timeSinceStartedSpawning;
    private SpawningModel model;
    private CirclePlacer circlePlacer;
    private Dictionary<CircleType, ObjectPool> pools;

    private CircleCallback circleClickedCallback;
    private CircleCallback circleTimedOutCallback;

    private int activeCircles;

    public void SetCallbacks(CircleCallback circleClickedCallback, CircleCallback circleTimedOutCallback) {
        this.circleClickedCallback = circleClickedCallback;
        this.circleTimedOutCallback = circleTimedOutCallback;
    }

    private void Awake() {
        pools = new Dictionary<CircleType, ObjectPool>() {
            { CircleType.Black, blackCirclesPool },
            { CircleType.Green, greenCirclesPool }
        };
        model = new SpawningModel(balanceData);
        circlePlacer = GetComponent<CirclePlacer>();
        timeSinceStartedSpawning = 0;
    }

    private void Update() {
        if (!gameClock.IsRunning)
            return;
        timeSinceStartedSpawning += gameClock.DeltaTime;
        if (CanSpawnCircle) {
            var circleData = model.GetCircleData(timeSinceStartedSpawning);
            if (circleData.circleType != CircleType.None)
                SpawnCircle(circleData);
        }
    }
    
    private void SpawnCircle(SpawningModel.CircleData circleData) {
        var circle = circlePlacer.PlaceCircleFromPool(pools[circleData.circleType]);
        circle.Initialize(circleData.lifeTime, circleClickedCallback, circleTimedOutCallback);
        circle.Died += HandleCircleDied;
        activeCircles++;
    }

    private void HandleCircleDied(Circle circle) {
        pools[circle.circleType].Despawn(circle.gameObject);
        activeCircles--;
    }
}
