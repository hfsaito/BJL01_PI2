using System.Collections.Generic;
using System.Linq;

using Assets.App.Common.Clues;

namespace Assets.App.Common.Data
{
    public enum WeaponId
    {
        None,
        Knife,
    }

    public static class WeaponsData
    {
        private static readonly Dictionary<WeaponId, string> NotepadOptionWeapon = new()
        {
            { WeaponId.None, "" },
            { WeaponId.Knife, "Faca" },
        };
        public static string GetNotepadLabel(WeaponId weaponId)
        {
            return NotepadOptionWeapon[weaponId];
        }

        private delegate bool WeaponChecker();
        private static readonly Dictionary<WeaponId, WeaponChecker> NotepadCheckers = new()
        {
            { WeaponId.None, () => true },
            {
                WeaponId.Knife,
                () =>
                {
                    return Globals.Clues.ContainsKey(ClueId.WIDOWER_D3_KNIFE) &&
                        Globals.Clues[ClueId.WIDOWER_D3_KNIFE];
                }
            }
        };
        public static WeaponId[] NotepadOptions()
        {
            return ((WeaponId[])System.Enum.GetValues(typeof(WeaponId)))
                .Where((weaponId) => NotepadCheckers[weaponId]())
                .ToArray();
        }
    }
}
