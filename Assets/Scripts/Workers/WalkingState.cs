using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Workers
{
    internal class WalkingState : WorkerState
    {
        protected WorkerDestination _destination;

        //protected GameObject _destinationObject;
        internal WalkingState(Worker worker, WorkerDestination workerDestination) : base(worker)
        {
            _destination = workerDestination;
            _worker._currentDestination = _destination;
        }

        protected override void BeforeStateBegin()
        {
            //get animator from worker gameobject

            base.BeforeStateBegin();
        }

        protected override async UniTask StateTask()
        {
            while(true)
            {
                if (Vector3.Distance(_destination.GetGameObject.transform.position, _worker.GetGameObject.transform.position) < .5f)
                {
                    break;
                }
                await UniTask.Yield();
            }

            OnStateEnd();

            //_destination.UseByWorker(_worker); //?
        }
    }
}
