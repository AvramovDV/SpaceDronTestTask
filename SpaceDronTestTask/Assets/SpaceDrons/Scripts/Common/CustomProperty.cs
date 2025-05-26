using System;

namespace Avramov.SpaceDrons
{
    public class CustomProperty<T>
    {
        private T _value;

        public T Value 
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value.Equals(value))
                    return;

                _value = value;
                ChangedEvent?.Invoke();
            }
        }

        public event Action ChangedEvent;

        public void SetupWithoutNotify(T value)
        {
            _value = value;
        }
    }
}
