using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CirclePlacer : MonoBehaviour {
    #region Inspector
    public RectTransform gameArea;
    public GraphicRaycaster raycaster;
    #endregion

    public Circle PlaceCircleFromPool(ObjectPool circlePool) {
        var circle = circlePool.Spawn<Circle>(gameArea);
        ((RectTransform)circle.transform).anchoredPosition = GetPosition();
        return circle;
    }

    private Vector2 GetPosition() {
        var size = gameArea.rect.size;
        Vector2 position = Vector2.zero;
        bool foundPosition = false;
        var pointerData = new PointerEventData(EventSystem.current);
        var results = new List<RaycastResult>();
        while (!foundPosition) {
            results.Clear();
            position = new Vector2(Random.value, Random.value) * size;
            pointerData.position = GetScreenPosition(size, position);
            raycaster.Raycast(pointerData, results);
            foundPosition = results.Count == 0;
        }
        return GetAnchoredPosition(size, position);
    }

    private static Vector2 GetAnchoredPosition(Vector2 size, Vector2 position) {
        return position - 0.5f * size;
    }

    private Vector2 GetScreenPosition(Vector2 size, Vector2 position) {
        var gameAreaCenterInScreenSpace = new Vector2(Screen.width, Screen.height) * 0.5f + gameArea.anchoredPosition;
        return position + gameAreaCenterInScreenSpace - size * 0.5f;
    }
}
