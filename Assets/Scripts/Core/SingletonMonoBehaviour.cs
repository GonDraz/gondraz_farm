using UnityEngine;

namespace Core
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected virtual bool IsDontDestroyOnLoad { get; set; } = false;

        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;
            if (IsDontDestroyOnLoad) DontDestroyOnLoad(this);
            
            OnInit();
        }

        protected virtual void OnInit()
        {
        }
    }
}