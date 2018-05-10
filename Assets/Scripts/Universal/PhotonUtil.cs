using ExitGames.Client.Photon;
using GameJolt.API;

public static class PhotonUtil {

    public static void SetProperty(this PhotonPlayer player, Key key, object value) {
        Util.Assert(PhotonNetwork.inRoom, "Not in room.");
        player.SetCustomProperties(
            new Hashtable() {
                { key, value }
            });
    }

    public static T GetProperty<T>(this PhotonPlayer player, Key key) {
        Util.Assert(PhotonNetwork.inRoom, "Not in room.");
        return (T) player.CustomProperties[key];
    }
}

public enum Key {
    ID
}