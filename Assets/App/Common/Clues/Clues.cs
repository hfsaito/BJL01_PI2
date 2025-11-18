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
        };
    }
}
