using Cysharp.Threading.Tasks;
using UnityEngine.Accessibility;

namespace Workers
{
    internal abstract class State
    {
        protected UniTask uniTask; 

        /// <summary>
        /// REMEMBER! IT IS NOT ENOUGHT THE CREATE NEW STATES! YOU MUST ALSO CALL StartState()
        /// Thank you, and I love you <3
        /// </summary>
        public State()
        {
            
        }

        public UniTask StartState()
        {
            BeforeStateBegin();
            //Starts the task loop
            uniTask = StateTask();
            return uniTask;
        }

        protected virtual void BeforeStateBegin()
        {
            
        }
        protected abstract void OnStateEnd();
      

        protected abstract UniTask StateTask();
    }
}
