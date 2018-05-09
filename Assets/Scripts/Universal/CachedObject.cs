using UnityEngine;

public class CachedObject<T> where T : MonoBehaviour {
    private T _item;

    public T Item {
        get {
            if (_item == null) {
                _item = GameObject.FindObjectOfType<T>();
            }
            return _item;
        }
    }
}