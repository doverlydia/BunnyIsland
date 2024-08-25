using FSM;

namespace Workers
{
    class WorkerFlow : Flow
    {
        protected override void SetDefaultFlow()
        {
            Add<SetTargetState>();
            Add<ObjectiveSubFlowState>();
            Add<EndState>();
        }

        protected override void SetBindings()
        {
            Bind<SetTargetState, SleepingState>(SetTargetState.GoToSleepStateKey);
            Bind<ObjectiveSubFlowState, SetTargetState>(ObjectiveSubFlowState.GoToSetTargetStateKey);
        }
    }
}
