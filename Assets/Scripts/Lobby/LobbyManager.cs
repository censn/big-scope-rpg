using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour {
    [SerializeField]
    private byte maxPlayersPerRoom;

    [SerializeField]
    private float refreshRate;

    [SerializeField]
    private Listing listingPrefab;

    [SerializeField]
    private Transform listingParent;

    [SerializeField]
    private Button join;

    public RoomInfo selected;

    public void CreateRoom() {
        string roomName = string.Format("{0}'s game", PhotonNetwork.player.ID);
        if (!PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null)) {
            Util.Log("Create room failed.");
        } else {
            SceneUtil.LoadScene(Scene.WAITING_ROOM);
            Util.Log("Room created.");
        }
    }

    public void JoinSelectedRoom() {
        if (selected != null && PhotonNetwork.JoinRoom(selected.Name)) {
            SceneUtil.LoadScene(Scene.WAITING_ROOM);
            Debug.Log("Loaded room.");
        } else {
            Util.Log("Join room failed.");
        }
    }

    public void GoBack() {
        SceneUtil.LoadScene(Scene.MAIN_MENU);
    }

    private void Start() {
        Util.Assert(PhotonNetwork.JoinLobby(), "lobby join not successful");
        StartCoroutine(RefreshRoomListings());
    }

    private IEnumerator RefreshRoomListings() {
        while (true) {
            Util.Log("Start room refresh with {0} rooms", PhotonNetwork.GetRoomList().Length);
            UpdateRoomListings();
            yield return new WaitForSeconds(refreshRate);
        }
    }

    private void UpdateRoomListings() {
        RoomInfo[] roomInfos = PhotonNetwork.GetRoomList();
        HashSet<string> roomNames = new HashSet<string>(roomInfos.Select(i => i.Name));

        HashSet<string> alreadyListedRooms;
        DestroyAllListings(roomNames, out alreadyListedRooms);

        foreach (RoomInfo roomInfo in roomInfos) {
            Util.Log(roomInfo.Name);
            if (!alreadyListedRooms.Contains(roomInfo.Name)) {
                Instantiate(listingPrefab, listingParent).Init(roomInfo);
            }
        }
    }

    private void DestroyAllListings(HashSet<string> newRoomNames, out HashSet<string> alreadyListedRooms) {
        alreadyListedRooms = new HashSet<string>();
        foreach (Listing child in listingParent.GetComponentsInChildren<Listing>()) {
            if (!newRoomNames.Contains(child.RoomName)) {
                Destroy(child.gameObject);
            } else {
                alreadyListedRooms.Add(child.RoomName);
            }
        }
    }

    private void Update() {
        join.interactable = (selected != null);
    }
}