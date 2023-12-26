namespace UI.Screens
{
    public abstract class Screen : Core.UI.UI
    {
        public abstract override void Subscribe();
        public abstract override void Unsubscribe();
    }
}