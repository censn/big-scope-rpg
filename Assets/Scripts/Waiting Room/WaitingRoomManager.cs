using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingRoomManager : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI roomName;

    public void GoBack() {
        PhotonNetwork.LeaveRoom();
        SceneUtil.LoadScene(Scene.LOBBY);
    }

    private void Start() {
        
    }

    private void Update() {
        Room current = PhotonNetwork.room;
        if (current != null) {
            roomName.text = string.Format("{0} ({1}/{2})", current.Name, current.PlayerCount, current.MaxPlayers);
        }
    }
}
