using System;
using System.Collections.Generic;
using System.Linq;
using Assets.App.Common.Clues;

public enum BlameField
{
    SUSPECT,
    WEAPON,
    CRIME_SCENE,
    MOTIVE,
}

public enum BlameOptionSuspect
{
    NONE,
    WIDOWER,
}

public enum BlameOptionsWeapons
{
    NONE,
    // WIDOWER,
}

public enum BlameOptionsLocation
{
    NONE,
    // WIDOWER,
}

public enum BlameOptionsMotivation
{
    NONE,
    // WIDOWER,
}

public static class BlameData
{

    public static void UpdateAvailableValues()
    {
        UpdateSuspects();
    }

    private static BlameOptionSuspect SuspectSelected;
    private readonly static List<BlameOptionSuspect> SuspectsAvailable = new();
    private static int SuspectIndexSelected;
    public static void SelectPrevSuspectByIndex()
    {
        SuspectIndexSelected -= 1;
        if (SuspectIndexSelected < 0) SuspectIndexSelected += SuspectsAvailable.Count();
        SuspectSelected = SuspectsAvailable[SuspectIndexSelected];
    }
    public static void SelectNextSuspectByIndex()
    {
        SuspectIndexSelected += 1;
        if (SuspectIndexSelected >= SuspectsAvailable.Count()) SuspectIndexSelected %= SuspectsAvailable.Count();
        SuspectSelected = SuspectsAvailable[SuspectIndexSelected];
    }
    private static readonly Dictionary<BlameOptionSuspect, string> SuspectToLabel = new()
    {
        {BlameOptionSuspect.NONE, "--" },
        {BlameOptionSuspect.WIDOWER, "Viúvo" },
    };
    public static string GetSuspectLabel()
    {
        return SuspectToLabel[SuspectSelected];
    }
    private static readonly Dictionary<BlameOptionSuspect, ClueId[]> SuspectToRequiredClues = new()
    {
        {BlameOptionSuspect.NONE, new ClueId[] {} },
        {BlameOptionSuspect.WIDOWER, new ClueId[] { ClueId.WIDOWER_D1_ANGRY } },
    };
    private static void UpdateSuspects()
    {
        SuspectsAvailable.Clear();
        bool requiredClueValue = false;
        foreach(var (suspect, clueIds) in SuspectToRequiredClues)
        {
            if (
                clueIds.Length == 0 ||
                clueIds.All(clueId =>
                    Globals.Clues.TryGetValue(clueId, out requiredClueValue) &&
                    requiredClueValue
                )
            )
            {
                SuspectsAvailable.Add(suspect);
            }
        }
    }
}
