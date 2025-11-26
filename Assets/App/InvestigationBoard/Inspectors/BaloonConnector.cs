namespace Assets.App.InvestigationBoard.Inspectors
{
    public static class BaloonConnector
    {
        public static event System.Action<string> OnInspectPointerEnter;
        public static event System.Action OnInspectPointerExit;
        public static void InspectPointerEnter(string baloonPath)
        {
            OnInspectPointerEnter.Invoke(baloonPath);
        }
        public static void InspectPointerExit()
        {
            OnInspectPointerExit.Invoke();
        }
    }
}
