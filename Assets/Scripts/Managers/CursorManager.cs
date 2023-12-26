using Core.Base;
using Managers.StateManagers;
using UnityEngine;

namespace Managers
{
    public class CursorManager : Base
    {
        public override void Subscribe()
        {
            base.Unsubscribe();
            // GlobalStateManager.MenuState.Enter += UnlockAndShowCursor;
            // GlobalStateManager.PauseState.Enter += UnlockAndShowCursor;
            
            GlobalStateManager.InGameState.Enter += LockAndHideCursor;
            GlobalStateManager.InGameState.Exit += UnlockAndShowCursor;
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            // GlobalStateManager.PauseState.Enter -= UnlockAndShowCursor;
            // GlobalStateManager.MenuState.Enter -= UnlockAndShowCursor;
            
            GlobalStateManager.InGameState.Enter -= LockAndHideCursor;
            GlobalStateManager.InGameState.Exit -= UnlockAndShowCursor;
        }

        private static void LockAndHideCursor() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void UnlockAndShowCursor() {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}