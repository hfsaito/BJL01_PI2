using System.Collections.Generic;
using System.Linq;
using Assets.App.Common.Clues;

namespace Assets.App.Common.Data
{
    public enum CharacterId
    {
        None,
        Victim,
        Widower,
        Friend,
        Paramour
    }

    public static class CharactersData
    {
        public static Dictionary<CharacterId, string> TextByCharacter = new()
        {
            { CharacterId.None, "" },
            { CharacterId.Victim, "Rosiane Freitas" },
            { CharacterId.Widower, "O viúvo" },
            { CharacterId.Friend, "A amiga" },
            { CharacterId.Paramour, "O estranho" },
        };

        public static Dictionary<CharacterId, string> ToBaloonResourcePath = new()
        {
            { CharacterId.None, "" },
            { CharacterId.Victim, "EvidenceBaloons/Characters/Victim" },
            { CharacterId.Widower, "EvidenceBaloons/Characters/Widower" },
            { CharacterId.Friend, "EvidenceBaloons/Characters/Friend" },
            { CharacterId.Paramour, "EvidenceBaloons/Characters/Paramour" },
        };

        private delegate bool CharacterChecker();
        private static readonly Dictionary<CharacterId, CharacterChecker> CharacterForBoard = new()
        {
            { CharacterId.None, () => false },
            { CharacterId.Victim, () => true },
            {
                CharacterId.Widower,
                () => Globals.DayCount >= 1
            },
            {
                CharacterId.Friend,
                () => Globals.DayCount >= 2
            },
            {
                CharacterId.Paramour,
                () =>
                    (
                        Globals.Clues.ContainsKey(ClueId.PARAMOUR_D2_SAD) &&
                        Globals.Clues[ClueId.PARAMOUR_D2_SAD]
                    ) ||
                    (
                        Globals.Clues.ContainsKey(ClueId.PARAMOUR_D3_FLOWERS) &&
                        Globals.Clues[ClueId.PARAMOUR_D3_FLOWERS]
                    )

            },
        };
        public static bool IsCharacterUnlockedInBoard(CharacterId character)
        {
            return CharacterForBoard[character]();
        }

        private static readonly Dictionary<CharacterId, string> NotepadOptionByCharacter = new()
        {
            { CharacterId.None, "" },
            { CharacterId.Victim, "" },
            { CharacterId.Widower, "Viúvo" },
            { CharacterId.Friend, "Amiga" },
            { CharacterId.Paramour, "Estranho" },
        };
        public static string GetNotepadLabel(CharacterId character)
        {
            return NotepadOptionByCharacter[character];
        }

        private static readonly Dictionary<CharacterId, CharacterChecker> NotepadCheckers = new()
        {
            { CharacterId.None, () => true },
            { CharacterId.Victim, () => false },
            {
                CharacterId.Widower,
                () => true
            },
            {
                CharacterId.Friend,
                () => false
            },
            {
                CharacterId.Paramour,
                () => false
            },
        };
        public static CharacterId[] NotepadOptions()
        {
            return ((CharacterId[])System.Enum.GetValues(typeof(CharacterId)))
                .Where((characterId) => NotepadCheckers[characterId]())
                .ToArray();
        }
    }
}
