using System.Collections.Generic;
using System.Linq;

using Assets.App.Common.Clues;

namespace Assets.App.Common.Data
{
    public enum ReasonId
    {
        None,
        Cheating,
    }

    public static class ReasonsData
    {
        private static readonly Dictionary<ReasonId, string> NotepadOptionReason = new()
        {
            { ReasonId.None, "" },
            { ReasonId.Cheating, "Traição" },
        };
        public static string GetNotepadLabel(ReasonId reasonId)
        {
            return NotepadOptionReason[reasonId];
        }

        private delegate bool ReasonChecker();
        private static readonly Dictionary<ReasonId, ReasonChecker> NotepadCheckers = new()
        {
            { ReasonId.None, () => true },
            {
                ReasonId.Cheating,
                () =>
                {
                    return Globals.Clues.ContainsKey(ClueId.PARAMOUR_D3_FLOWERS) &&
                        Globals.Clues[ClueId.PARAMOUR_D3_FLOWERS];
                }
            }
        };
        public static ReasonId[] NotepadOptions()
        {
            return ((ReasonId[])System.Enum.GetValues(typeof(ReasonId)))
                .Where((reasonId) => NotepadCheckers[reasonId]())
                .ToArray();
        }
    }
}
