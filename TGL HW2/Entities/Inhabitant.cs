using TGL_HW2.Collections;

namespace TGL_HW2.Entities
{
    class Inhabitant : Person
    {
        public delegate int? ScanHandler(ref People people);
        public ScanHandler? scanHandler;

        public Inhabitant(int taskDelayInterval) : base(taskDelayInterval)
        {
        }

        public event ScanHandler EnemyDetected
        {
            add
            {
                scanHandler += value;
                Console.WriteLine($"{value.Method.Name} added");
            }
            remove
            {
                scanHandler -= value;
                Console.WriteLine($"{value.Method.Name} removed");
            }
        }

        public async override Task ActAsync()
        {
            Console.WriteLine("Inhabitant is living");
            await Task.Delay(_taskDelayInterval);
        }

        public override int? Scan(ref People people)
        {
            Console.WriteLine("Inhabitant is scanning people");
            for (int i = 0; i < people.Size; ++i)
            {
                if (people[i] is Enemy enemy)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
