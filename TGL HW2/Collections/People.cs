using System.Collections;
using TGL_HW2.Entities;

namespace TGL_HW2.Collections
{
    public class People : IEnumerable<Person>, IEnumerator<Person>, IDisposable
    {
        private readonly List<Person> _people;
        private int _position = -1;
        public int Size { get { return _people.Count; } }

        public People(int size)
        {
            _people = new List<Person>(size);
        }

        public Person this[int index]
        {
            get { return _people[index]; }
            set { _people[index] = value; }
        }

        bool IEnumerator.MoveNext()
        {
            if (_position < _people.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        object IEnumerator.Current
        {
            get { return _people[_position]; }
        }

        public Person Current => _people[_position];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        void IEnumerator.Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return (IEnumerator<Person>)this;
        }

        public void Remove(int position)
        {
            _people.RemoveAt(position);
        }

        public void Add(Person person)
        {
            _people.Add(person);
        }
    }
}
