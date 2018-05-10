using GameJolt.API;
using GameJolt.UI;
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
    private Button signIn;

    [SerializeField]
    private PopulationTracker population;

    private bool CanJoinLobby {
        get {
            return population.IsBelowCapacity 
                && connecting.enabled 
                && GameJoltAPI.Instance.HasSignedInUser;
        }
    }

    public void SignIn() {
        GameJoltUI.Instance.ShowSignIn();
    }

    public void JoinLobby() {
        SceneUtil.LoadScene(Scene.LOBBY);
    }

    private void Start() {
        if (PhotonNetwork.ConnectUsingSettings("apple")) {
            connecting.text = "Ready to join lobby.";
            connecting.enabled = true;
        } else {
            connecting.text = "Unable to connect. Max CCU might have been reached or something else.";
        }
    }

    private void Update() {
        joinLobby.interactable = CanJoinLobby;
        signIn.interactable = !GameJoltAPI.Instance.HasSignedInUser;
    }
}