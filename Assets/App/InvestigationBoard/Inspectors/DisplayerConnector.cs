namespace Assets.App.InvestigationBoard.Inspectors
{
    public static class DisplayerConnector
    {
        public static event System.Action<string> OnInspect;
        public static void Inspect(string text)
        {
            OnInspect.Invoke(text);
        }
    }
}
