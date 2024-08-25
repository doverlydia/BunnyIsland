using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class Flow
    {
        List<Type> _defaultFlow;
        Dictionary<Type, Dictionary<string, Type>> _contracts;

        State _currentState;

        public void CreateFlow()
        {
            Debug.Log($"Starting Flow {GetType()}");
            GoToNextState();
        }

        protected abstract void SetDefaultFlow();
        protected abstract void SetBindings();

        protected void Bind<T1, T2>(string key) where T1 : State where T2 : State
        {
            if (!_contracts.TryGetValue(typeof(T1), out var contract))
            {
                _contracts.Add(typeof(T1), new() { { key, typeof(T2) } });
            }
            else
            {
                contract.Add(key, typeof(T2));
            }
        }

        protected void Add<T>() where T : State
        {
            _defaultFlow.Add(typeof(T));
        }

        void GoToNextState(string key = null)
        {
            var typeOfCurrentState = _currentState.GetType();
            if (key != null)
            {
                if (_contracts.TryGetValue(typeOfCurrentState, out var contract)
                    && contract.TryGetValue(key, out var nextState))
                {
                    EnterState(nextState);
                }
                else
                {
                    _currentState?.Cancel();
                    throw new Exception($"No binding exists for {_currentState.GetType()} under the key {key}!");
                }
            }
            else
            {
                var index = _defaultFlow.IndexOf(_currentState.GetType());
                if (index == _defaultFlow.Count - 1)
                {
                    Debug.Log($"Finished Flow {GetType()}");
                    return;
                }

                var nextState = _defaultFlow[index];
                EnterState(nextState);
            }
        }

        void EnterState(Type state)
        {
            Debug.Log($"Entering state {state}");
            _currentState = (State)Activator.CreateInstance(state);
            _currentState.Enter();
        }
    }
}
