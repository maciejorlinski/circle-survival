using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    #region Inspector
    public GameObject prefab;
    public int initialSize = 2;
    #endregion

    private Queue<GameObject> pool;
    private int numberOfElements;

    private void Awake() {
        if (pool == null)
            InitPool();
    }

    private void InitPool() {
        if (prefab == null)
            throw new System.InvalidOperationException(string.Format("Pool [{0}] has no prefab assigned", name));
        pool = new Queue<GameObject>(initialSize);
        for (int i = 0; i < initialSize; ++i)
            Expand();
    }

    private void Expand() {
        GameObject newInstance = Instantiate<GameObject>(prefab, this.transform.parent);
        newInstance.gameObject.name += string.Format(" {0}", ++numberOfElements);
        newInstance.gameObject.SetActive(false);
        pool.Enqueue(newInstance);
    }

    private GameObject GetNextElement() {
        if (pool == null)
            InitPool();
        if (pool.Count == 0)
            Expand();
        return pool.Dequeue();
    }

    public T Spawn<T>(Transform newParent) {
        var instance = GetNextElement();
        instance.transform.SetParent(newParent, false);
        instance.SetActive(true);
        return instance.GetComponent<T>();
    }

    public void Despawn(GameObject instance) {
        pool.Enqueue(instance);
        instance.gameObject.SetActive(false);
        instance.transform.SetParent(this.transform, false);
    }
}
