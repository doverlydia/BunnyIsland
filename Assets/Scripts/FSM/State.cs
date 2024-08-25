using System;

namespace FSM
{
    public abstract class State
    {
        internal event Action<string> NextStateCalled;

        public abstract void Enter();
        protected abstract void Exit();
        public abstract void Cancel();

        protected void GoToNextState(string id = null)
        {
            Exit();
            NextStateCalled?.Invoke(id);
        }
    }
}
