using Core;
using Core.Base;
using Core.StateMachine;

namespace Managers
{
    public abstract class BaseStateManager : Base
    {
        protected readonly StateMachine StateMachine = new();

        private void Update()
        {
            StateMachine.Tick();
        }
    }
}