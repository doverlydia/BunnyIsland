using FSM;

namespace WorkersFlow
{
    class ObjectiveSubFlowState : State<WorkerFlowModel>
    {
        internal const string GoToSetTargetStateKey = "GoToSetTargetStateKey";

        ObjectiveSubFlow _objectiveFlow = new();

        public override void Enter()
        {
            _objectiveFlow.CreateFlow();
            _objectiveFlow.OnComplete += GoToSetTarget;
        }

        void GoToSetTarget()
        {
            GoToNextState(GoToSetTargetStateKey);
        }

        protected override void Exit()
        {
            Clean();
        }

        public override void Cancel()
        {
            Clean();
        }

        void Clean()
        {
            _objectiveFlow.OnComplete -= GoToSetTarget;
        }
    }
}
