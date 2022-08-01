using TGL_HW2.Collections;

namespace TGL_HW2.Entities
{
    class Soldier : Inhabitant
    {
        public Soldier(int taskDelayInterval) : base(taskDelayInterval)
        {
        }

        public async override Task ActAsync()
        {
            Console.WriteLine("Soldier is guarding");
            await Task.Delay(_taskDelayInterval);
        }

        public override int? Scan(ref People people)
        {
            Console.WriteLine("Soldier is scanning people");
            for (int i = 0; i < people.Size; ++i)
            {
                if (people[i] is Enemy enemy)
                {
                    people[i] = new Inhabitant(_taskDelayInterval);
                }
            }
            return null;
        }
    }
}
