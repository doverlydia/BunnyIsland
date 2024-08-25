using UnityEngine;

namespace Workers
{
    internal abstract class Worker
    {
        //refs:
        protected GameObject _gameObject;

        // Stats:
        protected float _actionDelay; //Time to wait between actions
        // Agent stats:
        protected float _moveSpeed;
        // Gatherer stats:
        protected float _gatherRate; //Now just per-strike
        protected float _gatherCapacity;
        protected float _amountGathered;

        protected float _foodForageRate;
        protected float _foodCapacity;
        protected float _currentHunger; //maybe current filled?
        protected float _hungerComforotThreshold;
        protected float _hungerStarvingThreshold;

        public WorkerDestination _currentDestination;
        public WorkerDestination _assignedStation;
        //public WorkerDestination GetCurrentDestination => _currentDestination;
        //public WorkerDestination GetAssignedStation => _assignedStation;

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
        public virtual bool ResourcesFull()
        {
            return _amountGathered >= _gatherCapacity;
        }

        public GameObject GetGameObject => _gameObject;


        // Methods:

        public virtual void Init()
        {
            _amountGathered = 0;
        }
        //Navigation:
        protected virtual void WalkToDestionation(Vector3 destionation)
        {
            //agent walk to destination, do we know what to do when we get there?
        }
        //per state,
    }
}
