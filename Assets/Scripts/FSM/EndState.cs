namespace FSM
{
    public class EndState : State
    {
        public override void Enter()
        {
            GoToNextState();
        }

        public override void Cancel() { }

        protected override void Exit() { }
    }
}
