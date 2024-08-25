using UnityEngine;

namespace Workers
{
    internal abstract class WorkerDestination
    {
        public WorkerDestinationEnum DestinationEnum;

        protected GameObject _gameObject;
        public virtual GameObject GetGameObject => _gameObject;
        public abstract void UseByWorker(Worker worker);

    }
}
