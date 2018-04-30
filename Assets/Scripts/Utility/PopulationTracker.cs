using TMPro;
using UnityEngine;

public class PopulationTracker : MonoBehaviour {
    private const int MAX_ALLOWED_PLAYERS = 20;

    [SerializeField]
    private TextMeshProUGUI text;

    public bool IsBelowCapacity {
        get {
            return PhotonNetwork.countOfPlayers < MAX_ALLOWED_PLAYERS;
        }
    }

    private void Update() {
        text.SetText("{0}/{1}", PhotonNetwork.countOfPlayers, MAX_ALLOWED_PLAYERS);
    }
}