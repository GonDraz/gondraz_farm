using System;
using System.Collections.Generic;
using System.Linq;
using Managers.StateManagers;
using UnityEngine;

namespace Managers
{
    public class ApplicationManager : MonoBehaviour
    {
        private readonly List<Type> _stateManagers = new() { typeof(GlobalStateManager) };

        private void Awake()
        {
            foreach (var _gameObject in _stateManagers.Select(_stateManager =>
                         new GameObject(_stateManager.Name, _stateManager)))
            {
            }
        }


        private void Start()
        {
            Invoke("ApplicationLoadFinished", 2f);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            // if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Application") return;
            var app = new GameObject { name = "ApplicationManager" };
            app.AddComponent<ApplicationManager>();
        }

        private void ApplicationLoadFinished()
        {
            GlobalStateManager.Instance.ApplicationLoadFinished = true;
        }
    }
}