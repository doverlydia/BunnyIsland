using Cysharp.Threading.Tasks;
using System.Diagnostics;

namespace Workers
{
    internal class SetObjectiveState : WorkerState
    {
        public SetObjectiveState(Worker worker) : base(worker)
        {

        }


        protected override async UniTask StateTask()
        {
            if (_worker.IsHungry())
            {
                //check for food in radius

                //found food -> go to food.

                //didn't find food:
                //check if starving
                if (_worker.IsStraving())
                {
                    //_worker -> GoToSleep();
                    return;
                }
            }
            //check hunger 1#
                // if under comfort level -> check food in radius 1.1# 
                    // if none found, check if Starving 1.2#
                      // if starving -> Sleep (and stop)
                         // else continue to check 2#

            //check resource load 2#
            if(_worker.HasResource())
            {
                //if station is null -> sleep?
                //walk to station
                return;
            }


            //check resource in radius 3#
            //if found -> walk to resource
            //else sleep.
        }
    }
}
