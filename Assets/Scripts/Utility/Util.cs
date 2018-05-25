using ExitGames.Client.Photon;
using GameJolt.API;
using System;
using UnityEngine;
using UnityEngine.UI;

public static class Util {

    public static void Log(string message, params object[] args) {
        Debug.LogFormat(message, args);
    }

    public static void Assert(bool statement, string errorMessage = "Assertion failed.", params object[] args) {
        if (!statement) {
            throw new UnityException(string.Format(errorMessage, args));
        }
    }
}

public static class ScrollRectExtensions {
    public static void ScrollToTop(this ScrollRect scrollRect) {
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    public static void ScrollToBottom(this ScrollRect scrollRect) {
        scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}