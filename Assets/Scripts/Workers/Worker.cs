using UnityEngine;

namespace Workers
{
    internal abstract class Worker
    {
        //refs:
        protected GameObject _gameObject;

        // Stats:
        // Agent stats:
        protected float _moveSpeed;
        // Gatherer stats:
        protected float _gatherRate;
        protected float _gatherCapacity;
        protected float _amountGathered;

        protected float _foodForageRate;
        protected float _foodCapacity;
        protected float _currentHunger; //maybe current filled?
        protected float _hungerComforotThreshold;
        protected float _hungerStarvingThreshold;

        protected GameObject _currentTarget;
        protected GameObject _assignedStation;

        //State:
        protected WorkerStateEnum _workerStateEnum;

        //Some sort of Agent

        //Getters and such:
        public virtual bool IsHungry()
        {
            return _currentHunger <= _hungerComforotThreshold;
        }
        public virtual bool IsStraving()
        {
            return _currentHunger <= _hungerStarvingThreshold;
        }
        public virtual bool HasResource()
        {
            return _amountGathered > 0;
        }

        public GameObject GetGameObject => _gameObject;


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
