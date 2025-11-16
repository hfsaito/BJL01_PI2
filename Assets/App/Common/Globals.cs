using System;
using System.Collections.Generic;

using UnityEngine;

using Assets.App.Investigation.Clues;

public static class Globals
{
    public static Bounds WorldBounds;
    public static event Action<Clue> OnClueFound;

    public static Dictionary<string, bool> Clues = new();

    public static void ClueFound(Clue clue)
    {
        Clues.Add(clue.ClueName, true);
        OnClueFound.Invoke(clue);
    }
}
