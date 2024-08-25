using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class Flow
    {
        public event Action OnComplete;

        List<Type> _defaultFlow = new();
        Dictionary<Type, Dictionary<string, Type>> _contracts = new();
        State _currentState;

        public void CreateFlow()
        {
            Debug.Log($"Starting Flow {GetType()}");

            SetDefaultFlow();
            SetBindings();

            GoToNextState();
        }

        public void Cancel()
        {
            _currentState?.Cancel();
            Debug.Log($"Cancled flow {GetType()}");
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
            if (_currentState == null)
            {
                EnterState(_defaultFlow[0]);
                return;
            }

            if (key != null)
            {
                if (_contracts.TryGetValue(_currentState.GetType(), out var contract)
                    && contract.TryGetValue(key, out var nextState))
                {
                    EnterState(nextState);
                    return;
                }
                else
                {
                    _currentState?.Cancel();
                    throw new Exception($"No binding exists for {_currentState.GetType()} under the key {key}!");
                }
            }

            var index = _defaultFlow.IndexOf(_currentState.GetType());
            if (index == _defaultFlow.Count - 1)
            {
                Debug.Log($"Completed Flow {GetType()}");
                OnComplete?.Invoke();
                return;
            }

            EnterState(_defaultFlow[index + 1]);
        }

        void EnterState(Type state)
        {
            Debug.Log($"Entering state {state}");

            if (_currentState != null)
                _currentState.NextStateRequested -= GoToNextState;

            _currentState = CreateState(state);

            _currentState.NextStateRequested += GoToNextState;
            _currentState.Enter();
        }

        protected virtual State CreateState(Type state)
        {
            return (State)Activator.CreateInstance(state);
        }
    }

    public abstract class Flow<T> : Flow where T : FlowModel
    {
        protected T FlowModel;

        public Flow(T flowModel)
        {
            FlowModel = flowModel;
        }

        protected override State CreateState(Type state)
        {
            var instance = (State)Activator.CreateInstance(state);
            if (instance is State<T> requireModel)
                requireModel.Configure(FlowModel);

            return instance;
        }
    }
}
