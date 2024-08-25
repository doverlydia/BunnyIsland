using FSM;

namespace WorkersFlow
{
    class ObjectiveSubFlowState : State<WorkerFlowModel>
    {
        internal const string GoToSetTargetStateKey = "GoToSetTargetStateKey";

        public override void Cancel()
        {
            throw new System.NotImplementedException();
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        protected override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
