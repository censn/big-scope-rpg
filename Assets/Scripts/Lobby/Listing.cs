using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Listing : MonoBehaviour {
    private static CachedObject<LobbyManager> lobby = new CachedObject<LobbyManager>();

    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI listingDisplay;

    private RoomInfo room;

    public string RoomName {
        get {
            return room.Name;
        }
    }

    public void Init(RoomInfo room) {
        this.room = room;
    }

    public void Select() {
        lobby.Item.selected = this.room;
    }

    private void Update() {
        this.listingDisplay.SetText(string.Format("{0} ({1}/{2})", room.Name, room.PlayerCount, room.MaxPlayers));
        button.interactable = (lobby.Item.selected != this.room);
    }
}