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

    public abstract class State<T> : State where T : FlowModel
    {
        T FlowModel;

        internal void Configure(T flowModel)
        {
            FlowModel = flowModel;
        }
    }
}
