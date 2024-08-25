using FSM;

namespace WorkersFlow
{
    class WalkState : State
    {
        public override void Enter()
        {
            GoToNextState();
        }

        protected override void Exit()
        {
        }

        public override void Dispose()
        {
        }
    }
}
