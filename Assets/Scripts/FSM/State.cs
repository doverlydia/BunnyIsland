using System;

namespace FSM
{
    public abstract class State : IDisposable
    {
        internal event Action<string> NextStateRequested;

        public abstract void Enter();
        protected abstract void Exit();
        public abstract void Dispose();

        protected void GoToNextState(string id = null)
        {
            Exit();
            NextStateRequested?.Invoke(id);
        }
    }

    public abstract class State<T> : State where T : FlowModel
    {
        protected T FlowModel;

        internal void Configure(T flowModel)
        {
            FlowModel = flowModel;
        }
    }
}
