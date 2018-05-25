using UnityEngine;
using TMPro;

public class Message : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private RectTransform child;

    public Message Init(string author, string message, float width, Color color) {
        child.rect.Set(0, 0, width, child.rect.height);
        text.text = string.Format("<b><color=yellow>{0}:</color></b> {1}", author, message);
        text.color = color;
        return this;
    }
}
