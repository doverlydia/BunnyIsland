using FSM;

namespace Workers
{
    class SetTargetState : State
    {
        internal const string GoToSleepStateKey = "GoToSleepStateKey";

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
