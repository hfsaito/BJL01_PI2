using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.App.Common.Clues
{
    public static class Clues
    {
        public static Dictionary<ClueId, string> Detail = new()
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
    }
}
