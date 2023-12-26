namespace Core
{
    public abstract class SingletonMonoBehaviour<T> : Base.Base where T : Base.Base
    {
        protected abstract bool IsDontDestroyOnLoad();
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;
            if (IsDontDestroyOnLoad()) DontDestroyOnLoad(this);

            OnInit();
        }

        protected virtual void OnInit()
        {
        }
    }
}