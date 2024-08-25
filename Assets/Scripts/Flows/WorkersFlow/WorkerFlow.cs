using FSM;

namespace WorkersFlow
{
    class WorkerFlow : Flow<WorkerFlowModel>
    {
        public WorkerFlow(WorkerFlowModel flowModel) : base(flowModel)
        {
        }

        protected override void SetDefaultFlow()
        {
            Add<SetTargetState>();
            Add<ObjectiveSubFlowState>();
            Add<EndState>();
        }

        protected override void SetBindings()
        {
            Bind<ObjectiveSubFlowState, SetTargetState>(ObjectiveSubFlowState.GoToSetTargetStateKey);
            Bind<SetTargetState, EndState>(SetTargetState.GoToEndStateKey);
        }
    }
}
