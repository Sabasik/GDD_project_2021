using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static event Action<string> GameEndMessage;
    public static void SetMessage(string message) => GameEndMessage?.Invoke(message);
}
