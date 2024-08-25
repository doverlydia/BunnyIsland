namespace Workers
{
    internal class Flow
    {
        protected State _currentState;
        public State GetCurrentState { get => _currentState; }

        public void SetCurrentState(State state)
        {
            _currentState = state;  
        }
    }
}
