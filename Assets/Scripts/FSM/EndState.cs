namespace FSM
{
    public class EndState : State
    {
        public override void Enter()
        {
            GoToNextState();
        }

        public override void Dispose() { }

        protected override void Exit() { }
    }
}
