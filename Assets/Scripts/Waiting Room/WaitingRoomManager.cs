using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class WaitingRoomManager : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI roomName;

    [SerializeField]
    private TextMeshProUGUI usersText;

    private string Users {
        get {
            PhotonPlayer[] players = PhotonNetwork.playerList;
            List<string> names = new List<string>();
            foreach (PhotonPlayer player in players) {
                names.Add(player.NickName);
            }
            return string.Join("\n", names.ToArray());
        }
    }

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
            usersText.text = Users;
        }
    }
}
