using UnityEngine;

public class Prompt : MonoBehaviour {
    public event System.Action Closed;

    public virtual void Show() {
        this.gameObject.SetActive(true);
    }

    public virtual void Hide() {
        this.gameObject.SetActive(false);
        Closed?.Invoke();
    }
}
