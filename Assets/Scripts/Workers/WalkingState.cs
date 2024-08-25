using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class WalkingState : WorkerState
    {
        protected WorkerDestination destination;
        internal WalkingState(Worker worker, WorkerDestination workerDestination) : base(worker)
        {
            destination = workerDestination;
        }

        protected override async UniTask StateTask()
        {

            await UniTask.Yield();
        }
    }
}
