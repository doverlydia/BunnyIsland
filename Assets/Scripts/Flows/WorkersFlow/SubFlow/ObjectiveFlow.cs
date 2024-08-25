using FSM;

namespace WorkersFlow
{
    class ObjectiveSubFlow : Flow
    {
        protected override void SetDefaultFlow()
        {
            Add<WalkState>();
            Add<InvokeState>();
        }

        protected override void SetBindings()
        {
            throw new System.NotImplementedException();
        }
    }
}
