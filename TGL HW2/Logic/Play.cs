using TGL_HW2.Collections;
using TGL_HW2.Entities;

namespace TGL_HW2.Logic
{
    public static class Play
    {
        public static async Task Start(int taskDelayInterval)
        {
            var commander = new Soldier(taskDelayInterval);
            commander.EnemyDetected += commander.Scan;

            var random = new Random();
            var size = random.Next(6, 10);
            var people = new People(size);

            for (int i = 0; i < size; i++)
            {
                people.Add(random.Next(3) switch
                {
                    0 => new Inhabitant(taskDelayInterval),
                    1 => new Soldier(taskDelayInterval),
                    2 => new Enemy(taskDelayInterval)
                });
            }

            foreach (var person in people)
            {
                await person.ActAsync();
            }

            foreach (var person in people)
            {
                await Task.Delay(taskDelayInterval);
                var indexOfEnemy = person.Scan(ref people);
                if (indexOfEnemy != null)
                {
                    commander.scanHandler?.Invoke(ref people);
                    break;
                }
                if (person is Soldier || person is Enemy)
                {
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
