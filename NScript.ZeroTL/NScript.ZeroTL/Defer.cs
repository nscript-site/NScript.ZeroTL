namespace NScript.ZeroTL
{
    public unsafe ref struct Defer
    {
        public Defer(delegate*<void> action) { Action = action; }

        private delegate*<void> Action;

        public void Dispose()
        {
            if (Action != null)
            {
                Action();
                Action = null;
            }
        }

        public static Defer Run(delegate*<void> action)
        {
            return new Defer(action);
        }
    }
}
