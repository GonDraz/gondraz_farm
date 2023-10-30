using States.GlobalStates;

namespace Managers.StateManagers
{
    public class GlobalStateManager : BaseStateManager
    {
        
        private bool _applicationLoadFished;

        
        protected override void Start()
        {
            var preLoaderState = new PreLoaderState(this);
            var menuState = new MenuState(this);
            var inGameState = new InGameState(this);
            var pauseState = new PauseState(this);
            
            
            stateMachineManager.SetState(preLoaderState);
            
            AddTran(preLoaderState,menuState,() => _applicationLoadFished);
        }
    }
}