using FSM;

namespace Workers
{
    class ObjectiveSubFlowState : State
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
