using FSM;

namespace WorkersFlow
{
    public class InvokeState : State
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
