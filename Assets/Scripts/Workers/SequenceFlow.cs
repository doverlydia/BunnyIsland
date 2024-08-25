using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Workers
{
    internal class SequenceFlow : State
    {
        private State[] _states;
        public SequenceFlow(State[] states)
        {
            _states = states;
        }

        //public SubFlow(State[] states)
        //{
        //    _states = states;
        //}

        public async void StartSubFlow()
        {
            for (int i = 0; i < _states.Length; i++)
            {
                await _states[i].StartState();
            }
        }

        protected override void OnStateEnd()
        {
            throw new System.NotImplementedException();
        }

        protected override async UniTask StateTask()
        {
            for (int i = 0; i < _states.Length; i++)
            {
                await _states[i].StartState();
            }
        }
        
    }
}
