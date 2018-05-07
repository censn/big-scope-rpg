using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI connecting;

    [SerializeField]
    private Button joinLobby;

    [SerializeField]
    private PopulationTracker population;

    private bool CanJoinLobby {
        get {
            return population.IsBelowCapacity && !connecting.enabled;
        }
    }

    public void JoinLobby() {
        connecting.enabled = true;
        if (PhotonNetwork.ConnectUsingSettings("apple")) {
            PhotonNetwork.JoinLobby();
            SceneManager.LoadScene(1);
        }
    }

    private void Update() {
        joinLobby.interactable = CanJoinLobby;
        if (PhotonNetwork.connectedAndReady) {
            connecting.text = "Connected!";
        }
    }
}