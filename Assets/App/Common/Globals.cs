using System;

using UnityEngine;

using Assets.App.Investigation.Clues;

public static class Globals
{
    public static Bounds WorldBounds;
    public static event Action<Clue> OnClueFound;

    public static void ClueFound(Clue clue)
    {
        OnClueFound.Invoke(clue);
    }
}
