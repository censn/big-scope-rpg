using ExitGames.Client.Photon;
using UnityEngine;

public abstract class EventInfo {
    private const string TYPE_KEY = "ty";

    private Event type;

    public void Init(Hashtable info) {
        Util.Assert((Event)info[TYPE_KEY] == type, "Type mismatch. Expected {0}, got {1} instead", type, (Event)info[TYPE_KEY]);

        InitHelper(info);
    }

    public Hashtable ToHashtable() {
        Hashtable hashtable = new Hashtable();
        hashtable.Add(TYPE_KEY, type);
        ToHashtableHelper(hashtable);
        return hashtable;
    }

    protected abstract void InitHelper(Hashtable info);

    protected abstract void ToHashtableHelper(Hashtable info);
}
