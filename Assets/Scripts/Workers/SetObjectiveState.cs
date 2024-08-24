using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class SetObjectiveState : WorkerState
    {
        public SetObjectiveState(Worker worker) : base(worker)
        {

        }

        protected override void OnStateEnd()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnStateFixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnStateUpdate()
        {
            throw new System.NotImplementedException();
        }

        protected override async UniTask StateTask()
        {
            while (true)
            {

                await UniTask.Yield();
            }
        }
    }
}
