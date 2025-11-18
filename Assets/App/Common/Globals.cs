using System;
using System.Collections.Generic;

using UnityEngine;

using Assets.App.Common.Clues;

public static class Globals
{
    public static Bounds WorldBounds;
    public static event Action<ClueId> OnClueFound;
    public static Dictionary<ClueId, bool> Clues = new();

    public static void ClueFound(ClueId clueId)
    {
        Clues.Add(clueId, true);
        OnClueFound.Invoke(clueId);
    }

    public static event Action<ClueId> OnClueInspected;
    public static void ClueInspected(ClueId clueId)
    {
        OnClueInspected.Invoke(clueId);
    }

    public static int DayCount = 1;
}
