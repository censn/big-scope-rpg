using TMPro;
using UnityEngine;

public class Listing : MonoBehaviour {

    [SerializeField]
    private int maxAllowedPlayersPerRoom;

    [SerializeField]
    private TextMeshProUGUI listingDisplay;

    private new string name;
    private RoomInfo room;

    public void Init(string name, RoomInfo room) {
        this.name = name;
        this.room = room;
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(this.name);
    }

    private void Update() {
        this.listingDisplay.SetText(string.Format("{0} ({1}/{2})", name, room.PlayerCount, maxAllowedPlayersPerRoom));
    }
}