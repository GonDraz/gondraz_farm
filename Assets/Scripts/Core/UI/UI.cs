namespace Core.UI
{
    public abstract class UI : Base.Base
    {
        private void Awake()
        {
            Subscribe();
        }

        protected override void OnEnable()
        {
            SubscribeChild();
        }

        protected override void OnDisable()
        {
            UnsubscribeChild();
        }

        protected virtual void OnDestroy()
        {
            Unsubscribe();
        }

        protected virtual void Show()
        {
            Active();
        }

        protected virtual void Hide()
        {
            DeActive();
        }
    }
}