using System;
using System.Collections.Generic;
using Managers.StateManagers;
using UnityEngine;

namespace Managers
{
    public class ApplicationManager : MonoBehaviour
    {
        private readonly List<Type> _stateManagers = new() { typeof(GlobalStateManager) };

        private void Awake()
        {
            foreach (var _stateManager in _stateManagers)
            {
                var _gameObject = new GameObject(_stateManager.Name, _stateManager);
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            // if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Application") return;
            var app = new GameObject { name = "ApplicationManager" };
            app.AddComponent<ApplicationManager>();
        }
    }
}