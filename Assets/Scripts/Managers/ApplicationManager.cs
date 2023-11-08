using System;
using System.Collections.Generic;
using System.Linq;
using Managers.StateManagers;
using UnityEngine;

namespace Managers
{
    public class ApplicationManager : MonoBehaviour
    {
        private readonly List<Type> _managers = new() { typeof(GlobalStateManager), typeof(ControlManager) };

        private void Awake()
        {
            foreach (var gameObject in _managers.Select(manager =>
                         new GameObject(manager.Name, manager)))
                Debug.Log("Create :" + gameObject.name);
            
            ApplicationLoadFinished();
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
            Invoke("aaaaaaaaa",5f);
        }

        void aaaaaaaaa()
        {
            GlobalStateManager.Instance.GamePlay = true;
        }
    }
}