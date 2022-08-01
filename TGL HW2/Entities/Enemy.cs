using TGL_HW2.Collections;

namespace TGL_HW2.Entities
{
    class Enemy : Person
    {
        public Enemy(int taskDelayInterval) : base(taskDelayInterval)
        {
        }

        public async override Task ActAsync()
        {
            Console.WriteLine("Enemy is sneaking");
            await Task.Delay(_taskDelayInterval);
        }

        public override int? Scan(ref People people)
        {
            Console.WriteLine("Enemy is scanning people");
            for (int i = 0; i < people.Size; ++i)
            {
                if (people[i] is Soldier soldier)
                {
                    people.Remove(i);
                }
            }
            return null;
        }
    }
}
