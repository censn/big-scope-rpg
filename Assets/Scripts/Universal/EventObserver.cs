using ExitGames.Client.Photon;
using UnityEngine;

public abstract class EventObserver : MonoBehaviour {

    protected abstract void HandleEvent(Event e, Hashtable content);

    private void OnEnable() {
        PhotonNetwork.OnEventCall += this.OnEvent;
    }

    private void OnDisable() {
        PhotonNetwork.OnEventCall -= this.OnEvent;
    }

    private void OnEvent(byte eventCode, object content, int senderID) {
        Event e = (Event)eventCode;
        Debug.LogFormat("{0} recieved event with code={1}, enum={2}", this.name, eventCode, e);
        Hashtable table = (Hashtable)content;
        HandleEvent(e, table);
    }
}
