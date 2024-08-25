using FSM;

namespace WorkersFlow
{
    class SetTargetState : State<WorkerFlowModel>
    {
        public override void Enter()
        {
            GoToNextState();
        }
        protected override void Exit()
        {
        }

        public override void Cancel()
        {
        }

    }
}
