using UnityEngine;

namespace Workers
{
    internal abstract class WorkerDestination
    {
        protected GameObject _gameObject; //?
        public abstract void UseByWorker(Worker worker);
        public virtual GameObject GetGameObject => _gameObject;
    }
}
