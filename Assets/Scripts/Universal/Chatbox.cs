using ExitGames.Client.Photon;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Chatbox : EventObserver {
    private const int MAX_MESSAGES = 18;

    [SerializeField]
    private Message prefab;

    [SerializeField]
    private TMP_InputField input;

    [SerializeField]
    private RectTransform box;

    [SerializeField]
    private RectTransform scrollbarRect;

    [SerializeField]
    private Scrollbar scrollbar;

    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private VerticalLayoutGroup group;

    [SerializeField]
    private Transform messageParent;

    private bool IsMessageValid {
        get {
            return input.text != null && input.text.Trim().Length > 0;
        }
    }

    protected override void HandleEvent(Event e, Hashtable content) {
        if (e == Event.SEND_MESSAGE) {
            StartCoroutine(AddMessage(content));
        }
    }

    // force the group to update
    private IEnumerator AddMessage(Hashtable content) {
        bool shouldScrolldown = scrollRect.verticalNormalizedPosition <= float.Epsilon;

        MessageInfo info = new MessageInfo(content);

        Message message = Instantiate(prefab, messageParent);
        message.Init(info.AuthorName, info.Message, box.rect.width - scrollbarRect.rect.width, Color.clear); // first to setup widths

        Message[] childMessages = messageParent.GetComponentsInChildren<Message>();
        if (childMessages.Length > MAX_MESSAGES) {
            Destroy(childMessages[0].gameObject);
        }
        yield return new WaitForEndOfFrame();

        group.enabled = false;
        group.enabled = true;
        message.Init(info.AuthorName, info.Message, box.rect.width - scrollbarRect.rect.width, Color.white); // second pass to show

        yield return new WaitForEndOfFrame();
        if (shouldScrolldown) {
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
            Canvas.ForceUpdateCanvases();
        }
    }

    private void AddMessage(string message) {
        EventManager.RaiseEvent(Event.SEND_MESSAGE, new MessageInfo(PhotonNetwork.player.NickName, message));
    }

    private void Update() {
        if (Input.GetKeyDown(Shortcuts.SEND_MESSAGE)) {
            if (input.IsInteractable() && IsMessageValid) {
                AddMessage(input.text);
                input.text = string.Empty;
            }
            input.interactable = !input.interactable;
            if (input.IsInteractable()) {
                input.Select();
            }
        }
    }
}
