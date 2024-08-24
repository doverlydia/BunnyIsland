using UnityEngine;

namespace Workers
{
    internal abstract class Worker 
    {
        // Stats:
        // Agent stats:
        protected float _moveSpeed;
        protected float _searchRadius;
        // Gatherer stats:
        protected float _gatherRate;
        protected float _gatherCapacity;
        protected float _amountGathered;
        
        protected float _foodForageRate;
        protected float _foodCapacity;
        protected float _currentHunger; //maybe current filled?



        //State:
        protected WorkerStateEnum _workerStateEnum;


        //Some sort of Agent

        // Methods:

        public virtual void Init()
        {
            _amountGathered = 0;
        }

        //Search:
        protected virtual void Search()
        {

        }

        //Gathering:
        //Something that sets to GatheringState? 
        protected virtual void BeginGathering()
        {

        }
        //protected abstract bool EndGatheringCheck();
        protected virtual bool EndGatheringCheck()
        {
            return _amountGathered >= _gatherCapacity;
        }
        //Navigation:
        protected virtual void WalkToDestionation(Vector3 destionation)
        {
            //agent walk to destination, do we know what to do when we get there?
        }
        //per state,

    }
}
