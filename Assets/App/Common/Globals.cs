using System;
using System.Collections.Generic;

using UnityEngine;

using Assets.App.Common.Clues;

public static class Globals
{
    public static Bounds WorldBounds;
    public static event Action<ClueId> OnClueFound;
    public static Dictionary<ClueId, bool> Clues = new();
    // public static Dictionary<ClueId, bool> Clues = new()
    // {
    //     {ClueId.WIDOWER_D1_ANGRY, true},
    //     {ClueId.WIDOWER_D1_TYPEWRITER, true},
    //     {ClueId.FRIEND_D2_BRIEFCASE, true},
    //     {ClueId.FRIEND_D2_THEATER, true},
    //     {ClueId.PARAMOUR_D2_SAD, true},
    //     {ClueId.PARAMOUR_D3_FLOWERS, true},
    //     {ClueId.WIDOWER_D3_KNIFE, true},
    // };

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
