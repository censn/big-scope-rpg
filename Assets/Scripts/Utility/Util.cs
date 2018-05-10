using ExitGames.Client.Photon;
using GameJolt.API;
using System;
using UnityEngine;

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