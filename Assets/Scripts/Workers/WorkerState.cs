using Cysharp.Threading.Tasks;

namespace Workers
{
    internal class WorkerState : State
    {
        protected Worker _worker;

        public WorkerState(Worker worker) : base()
        {
            _worker = worker;
        }

        protected override void OnStateEnd()
        {
            throw new System.NotImplementedException();
        }

        protected override UniTask StateTask()
        {
            throw new System.NotImplementedException();
        }
    }
}
