using TGL_HW2.Collections;

namespace TGL_HW2.Entities
{
    public abstract class Person
    {
        protected int _taskDelayInterval;

        public Person(int taskDelayInterval)
        {
            _taskDelayInterval = taskDelayInterval;
        }

        public abstract Task ActAsync();

        public abstract int? Scan(ref People people);
    }
}
