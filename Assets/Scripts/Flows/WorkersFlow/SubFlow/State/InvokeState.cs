using FSM;

namespace WorkersFlow
{
    class InvokeState : State<WorkerFlowModel>
    {
        public override void Enter()
        {
            if(FlowModel.Target == null)
            {

            }
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
