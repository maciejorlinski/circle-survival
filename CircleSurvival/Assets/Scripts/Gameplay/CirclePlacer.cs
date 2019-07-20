using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlacer : MonoBehaviour {
    #region Inspector
    public RectTransform gameArea;
    #endregion

    public Circle PlaceCircleFromPool(ObjectPool circlePool) {
        var circle = circlePool.Spawn<Circle>(gameArea);
        var size = gameArea.rect.size;
        ((RectTransform)circle.transform).anchoredPosition = new Vector2(Random.value, Random.value) * size - 0.5f * size;
        return circle;
    }
}
