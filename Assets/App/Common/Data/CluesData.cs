using System.Collections.Generic;

using Assets.App.Common.Clues;

namespace Assets.App.Common.Data
{
    public static class CluesData
    {
        public static Dictionary<ClueId, string> TextByClue = new()
        {
            { ClueId.NONE, "" },
            { ClueId.WIDOWER_D1_ANGRY, "O viúvo tinha raiva da vítima" },
            { ClueId.WIDOWER_D1_TYPEWRITER, "Viúvo tinha acesso à uma máquina de escrever" },
            { ClueId.FRIEND_D2_BRIEFCASE, "A amiga tinha uma maleta estranha" },
            { ClueId.FRIEND_D2_THEATER, "A amiga entrou escondida no cinema" },
            { ClueId.PARAMOUR_D2_SAD, "Um homem estranho estava chorando pela suposta morte da vítima" },
            { ClueId.PARAMOUR_D3_FLOWERS, "O estranho deixou flores para vítima" },
            { ClueId.WIDOWER_D3_KNIFE, "O viúvo se desfez de uma faca com sangue" },
        };

        public static Dictionary<ClueId, string> ToBaloonResourcePath = new()
        {
            { ClueId.WIDOWER_D1_ANGRY, "EvidenceBaloons/Clues/Widower/Angry" },
            { ClueId.WIDOWER_D1_TYPEWRITER, "EvidenceBaloons/Clues/Widower/Typewriter" },
            { ClueId.FRIEND_D2_BRIEFCASE, "EvidenceBaloons/Clues/Friend/BRIEFCASE" },
            { ClueId.FRIEND_D2_THEATER, "EvidenceBaloons/Clues/Friend/Theater" },
            { ClueId.PARAMOUR_D2_SAD, "EvidenceBaloons/Clues/Paramour/Sad" },
            { ClueId.PARAMOUR_D3_FLOWERS, "EvidenceBaloons/Clues/Paramour/Flowers" },
            { ClueId.WIDOWER_D3_KNIFE, "EvidenceBaloons/Clues/Widower/Knife" },
        };

        public static bool IsClueUnlocked(ClueId clueId)
        {
            return Globals.Clues.ContainsKey(clueId) &&
                Globals.Clues[clueId];
        }
    }
}
