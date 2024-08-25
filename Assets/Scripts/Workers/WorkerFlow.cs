using Cysharp.Threading.Tasks;
using UnityEngine.SocialPlatforms;

namespace Workers
{
    internal class WorkerFlow : Flow
    {
        Worker _worker;

        Flow _subFlow;

        UniTask _setObjectiveTask;

        public override async void Start()
        {
            while (_worker != null)
            {

                await SetState(new SetObjectiveState(_worker));

                if (_worker._currentDestination == null)
                {

                    //SetState(sleep)
                    continue;
                }

                await SetState(new SequenceFlow(GetSimpleWalkToSequenceFlow()));
            }
        }

        State[] GetSimpleWalkToSequenceFlow()
        {
            return new State[] { new WalkingState(_worker, _worker._currentDestination), new UseByWorkerState(_worker, _worker._currentDestination) };
        }
    }
}
