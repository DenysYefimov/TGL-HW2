namespace TGL_HW2
{
    internal class Program
    {
        private const int TASK_DELAY_INTERVAL = 1000;
        abstract class Person
        {
            public abstract Task ActAsync();
        }

        class Inhabitant : Person
        {
            public delegate int? ScanHandler(ref List<Person> people);
            public ScanHandler? scanHandler;
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
                await Task.Delay(TASK_DELAY_INTERVAL);
            }

            public virtual int? Scan(ref List<Person> people)
            {
                Console.WriteLine("Inhabitant is scanning people");
                for (int i = 0; i < people.Count(); ++i)
                {
                    if (people[i] is Enemy enemy)
                    {
                        return i;
                    }
                }
                return null;
            }
        }

        class Soldier : Inhabitant
        {
            public async override Task ActAsync()
            {
                Console.WriteLine("Soldier is guarding");
                await Task.Delay(TASK_DELAY_INTERVAL);
            }

            public override int? Scan(ref List<Person> people)
            {
                Console.WriteLine("Soldier is scanning people");
                for (int i = 0; i < people.Count; ++i)
                {
                    if (people[i] is Enemy enemy)
                    {
                        people[i] = new Inhabitant();
                    }
                }
                return null;
            }
        }

        class Enemy : Person
        {
            public async override Task ActAsync()
            {
                Console.WriteLine("Enemy is sneaking");
                await Task.Delay(TASK_DELAY_INTERVAL);
            }
        }

        static async Task Main(string[] args)
        {
            var commander = new Soldier();
            commander.EnemyDetected += commander.Scan;
            var people = new List<Person>() { commander };

            var random = new Random();

            for(int i = 0; i < random.Next(6, 10); i++)
            {
                people.Add(random.Next(3) switch
                {
                    0 => new Inhabitant(),
                    1 => new Soldier(),
                    2 => new Enemy()
                });
            }

            foreach (var person in people)
            {
                await person.ActAsync();
            }

            for (int i = 1; i < people.Count; ++i)
            {
                if(people[i] is Inhabitant inhabitant)
                {
                    await Task.Delay(TASK_DELAY_INTERVAL);
                    var indexOfEnemy = inhabitant.Scan(ref people);
                    if (indexOfEnemy != null)
                    {
                        commander.scanHandler?.Invoke(ref people);
                    }
                    break;
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.GetType().Name);
            }
        }
    }
}