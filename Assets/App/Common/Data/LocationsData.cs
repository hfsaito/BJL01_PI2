using System.Collections.Generic;
using System.Linq;

using Assets.App.Common.Clues;

namespace Assets.App.Common.Data
{
    public enum LocationId
    {
        None,
        WidowerHouse,
    }

    public static class LocationsData
    {
        private static readonly Dictionary<LocationId, string> NotepadOptionLocation = new()
        {
            { LocationId.None, "" },
            { LocationId.WidowerHouse, "Casa do viúvo" },
        };
        public static string GetNotepadLabel(LocationId locationId)
        {
            return NotepadOptionLocation[locationId];
        }

        private delegate bool LocationChecker();
        private static readonly Dictionary<LocationId, LocationChecker> NotepadCheckers = new()
        {
            { LocationId.None, () => true },
            {
                LocationId.WidowerHouse,
                () =>
                {
                    return Globals.Clues.ContainsKey(ClueId.WIDOWER_D1_TYPEWRITER) &&
                        Globals.Clues[ClueId.WIDOWER_D1_TYPEWRITER];
                }
            }
        };
        public static LocationId[] NotepadOptions()
        {
            return ((LocationId[])System.Enum.GetValues(typeof(LocationId)))
                .Where((locationId) => NotepadCheckers[locationId]())
                .ToArray();
        }
    }
}
