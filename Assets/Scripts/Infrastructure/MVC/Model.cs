using System;

namespace MVC
{
    public class Model
    {
        public event Action OnChanged;

        protected void Changed()
        {
            OnChanged?.Invoke();
        }
    }
}