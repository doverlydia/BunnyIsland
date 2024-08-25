using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class UseByWorkerState : WorkerState
    {
        WorkerDestination _destinationToUse;
        internal UseByWorkerState(Worker worker, WorkerDestination destinationToUse) : base(worker)
        {
            _destinationToUse = destinationToUse;
        }

        protected override async UniTask StateTask()
        {
            //animate worker
            await UniTask.Delay(100);
            _destinationToUse.UseByWorker(_worker); //change this ugly shit
        }
    }
}
