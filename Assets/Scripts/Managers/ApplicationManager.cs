using System;
using System.Collections.Generic;
using System.Linq;
using Managers.StateManagers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ApplicationManager : MonoBehaviour
    {
        private readonly List<Type> _managers = new()
            { typeof(GlobalStateManager), typeof(ControlManager), typeof(CursorManager) };

        private void Awake()
        {
            foreach (var gameObject in _managers.Select(manager =>
                         new GameObject(manager.Name, manager)))
                Debug.Log("Create : <color=blue>" + gameObject.name+ "</color>");

            ApplicationLoadFinished();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            GlobalStateManager.GamePause = !hasFocus;
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            GlobalStateManager.GamePause = pauseStatus;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            if (SceneManager.GetActiveScene().name != "Farm") return;
            var app = new GameObject { name = "ApplicationManager" };
            app.AddComponent<ApplicationManager>();
        }

        private void ApplicationLoadFinished()
        {
            GlobalStateManager.ApplicationLoadFinished = true;
            Invoke("aaaaaaaaa", 5f);
        }

        private void aaaaaaaaa()
        {
            GlobalStateManager.GamePlay = true;
        }
    }
}