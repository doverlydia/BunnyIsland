using FSM;

namespace WorkersFlow
{
    class ObjectiveSubFlowState : State<WorkerFlowModel>
    {
        internal const string GoToSetTargetStateKey = "GoToSetTargetStateKey";

        ObjectiveSubFlow _objectiveFlow;

        public override void Enter()
        {
            _objectiveFlow = new();
            _objectiveFlow.OnComplete += GoToSetTarget;
            _objectiveFlow.Create();
        }

        void GoToSetTarget()
        {
            GoToNextState(GoToSetTargetStateKey);
        }

        protected override void Exit()
        {
            Clean();
        }

        public override void Dispose()
        {
            Clean();
        }

        void Clean()
        {
            _objectiveFlow.OnComplete -= GoToSetTarget;
        }
    }
}
