using ExitGames.Client.Photon;

public class MessageInfo : EventInfo {
    private const string AUTHOR_NAME_KEY = "an";
    private const string MESSAGE_KEY = "ms";

    public string AuthorName {
        get; private set;
    }

    public string Message {
        get; private set;
    }

    public MessageInfo(string authorName, string message) {
        this.AuthorName = authorName;
        this.Message = message;
    }

    public MessageInfo(Hashtable content) {
        Init(content);
    }

    protected override void InitHelper(Hashtable info) {
        AuthorName = (string)info[AUTHOR_NAME_KEY];
        Message = (string)info[MESSAGE_KEY];
    }

    protected override void ToHashtableHelper(Hashtable info) {
        info.Add(AUTHOR_NAME_KEY, AuthorName);
        info.Add(MESSAGE_KEY, Message);
    }
}