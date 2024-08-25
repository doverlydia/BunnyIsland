using FSM;

namespace WorkersFlow
{
    class SetTargetState : State<WorkerFlowModel>
    {
        internal const string GoToEndStateKey = "GoToEndStateKey";

        public override void Enter()
        {
            if (FlowModel.Target == null)
                GoToNextState(GoToEndStateKey);
            else
                GoToNextState();
        }

        protected override void Exit()
        {
        }

        public override void Dispose()
        {
            FlowModel.Target = null;
        }
    }
}
