using ExitGames.Client.Photon;
using UnityEngine;

public static class EventManager {
    public static void RaiseEvent<T>(Event type, T info) where T : EventInfo {
        Debug.LogFormat("Raised event of type={0}", type);
        PhotonNetwork.RaiseEvent((byte)type, info.ToHashtable(), true, new RaiseEventOptions() { Receivers = ReceiverGroup.All });
    }
}