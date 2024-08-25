using Cysharp.Threading.Tasks;
using UnityEngine.Accessibility;

namespace Workers
{
    internal abstract class State
    {
        UniTask uniTask; 
        public State()
        {
            OnStateBegin();
        }
        protected virtual void OnStateBegin()
        {
            //Starts the task loop
            uniTask = StateTask();
        }
        protected abstract void OnStateEnd();
      

        protected abstract UniTask StateTask();
    }
}
