namespace HandsOnWithBlazor.Client.Services
{
    public class SimpleStateContainerService<T> where T : struct
    {
        /// <summary>
        /// The State property with initial value
        /// </summary>
        public T Value { get; set; } = default!;
        /// <summary>
        /// The event that will be raised for state changed
        /// </summary>
        public event Action OnStateChange = default!;

        /// <summary>
        /// The method that will be accessed by the sender component 
        /// to update the state
        /// </summary>
        public void SetValue(T value)
        {
            Value = value;
            NotifyStateChanged();
        }

        /// <summary>
        /// The state change event notification
        /// </summary>
        private void NotifyStateChanged() => OnStateChange.Invoke();
    }
}