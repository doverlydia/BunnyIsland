using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class WorkerFlow : Flow
    {
        Worker _worker;

        Flow _subFlow;

        UniTask _setObjectiveTask;

        public async void Start()
        {
            _currentState = new SetObjectiveState(_worker);
            _setObjectiveTask = _currentState.StartState();

            await _setObjectiveTask;

            

            //switch (_worker.GetCurrentDestination.DestinationEnum)
            //{
            //    case WorkerDestinationEnum.Station:
            //        _subFlow = new Flow();
            //        _subFlow.SetCurrentState(new WalkingState(_worker));
            //        break;
            //    case WorkerDestinationEnum.Resource:

            //        break;
            //    case WorkerDestinationEnum.Food:

            //        break;
            //    case WorkerDestinationEnum.Other:

            //        break;
            //}
        }

    }
}
