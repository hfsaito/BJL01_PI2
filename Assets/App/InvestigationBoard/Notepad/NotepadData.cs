using System;
using System.Collections.Generic;
using System.Linq;
using Assets.App.Common.Clues;

using Assets.App.Common.Data;

namespace Assets.App.InvestigationBoard.Notepad
{
    public static class NotepadData
    {
        private static CharacterId characterId = CharacterId.None;
        public static void UpdateCharacter(CharacterId newCharacterId)
        {
            characterId = newCharacterId;
            OnReportChange.Invoke();
        }
        public static CharacterId GetCharacter()
        {
            return characterId;
        }

        private static WeaponId weaponId = WeaponId.None;
        public static void UpdateWeapon(WeaponId newWeaponId)
        {
            weaponId = newWeaponId;
            OnReportChange.Invoke();
        }
        public static WeaponId GetWeapon()
        {
            return weaponId;
        }

        private static LocationId locationId = LocationId.None;
        public static void UpdateLocation(LocationId newLocationId)
        {
            locationId = newLocationId;
            OnReportChange.Invoke();
        }
        public static LocationId GetLocation()
        {
            return locationId;
        }

        private static ReasonId reasonId = ReasonId.None;
        public static void UpdateReason(ReasonId newReasonId)
        {
            reasonId = newReasonId;
            OnReportChange.Invoke();
        }
        public static ReasonId GetReason()
        {
            return reasonId;
        }

        public static void Reset()
        {
            characterId = CharacterId.None;
            weaponId = WeaponId.None;
            locationId = LocationId.None;
            reasonId = ReasonId.None;
        }
        public static bool CanReport()
        {
            return characterId != CharacterId.None &&
                weaponId != WeaponId.None &&
                locationId != LocationId.None &&
                reasonId != ReasonId.None;
        }

        public static event Action OnReportChange;
    }
}
