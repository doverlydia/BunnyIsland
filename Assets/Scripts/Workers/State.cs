using Cysharp.Threading.Tasks;
using UnityEngine.Accessibility;

namespace Workers
{
    internal abstract class State
    {
        UniTask uniTask; 
        public State()
        { 
        
        }
        //protected abstract void OnStateBegin();
        protected virtual void OnStateBegin()
        {
            //Starts the task loop
            uniTask = StateTask();
        }
        protected abstract void OnStateEnd();
        protected abstract void OnStateUpdate();
        protected abstract void OnStateFixedUpdate();

        protected abstract UniTask StateTask();
        //{
        //    while (true)
        //    {
        //        await UniTask.Yield();
        //    }

        //    OnStateEnd();
        //}
    }
}
