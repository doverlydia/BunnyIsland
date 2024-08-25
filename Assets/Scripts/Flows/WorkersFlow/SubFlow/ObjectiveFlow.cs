using FSM;

namespace WorkersFlow
{
    class ObjectiveSubFlow : Flow
    {
        protected override void SetDefaultFlow()
        {
            Add<WalkState>();
            Add<InvokeState>();
            Add<EndState>();
        }

        protected override void SetBindings()
        {
        }
    }
}
