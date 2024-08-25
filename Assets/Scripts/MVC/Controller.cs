using UnityEngine;

namespace MVC
{
    public class Controller<T> : MonoBehaviour where T : Model
    {
        protected T _model;

        protected void SetModel(T model)
        {
            Clean();

            _model = model;
            _model.OnChanged += OnModelChanged;

            OnModelReplaced();
            OnModelChanged();
        }

        protected virtual void OnModelReplaced() { }

        protected virtual void OnModelChanged() { }

        protected virtual void Clean()
        {
            if (_model != null)
                _model.OnChanged -= OnModelChanged;
        }

        void OnDestroy()
        {
            Clean();
        }

    }
}
