using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class Flow
    {
        protected State _currentState;
        public State GetCurrentState { get => _currentState; }

        public virtual void Start()
        {
            //
        }

        public UniTask SetState(State state)
        {
            _currentState = state;
            return _currentState.StartState();
        }
    }
}
