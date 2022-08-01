using TGL_HW2.Logic;

namespace TGL_HW2
{
    internal class Program
    {
        private const int TASK_DELAY_INTERVAL = 1000;

        static async Task Main(string[] args)
        {
            await Play.Start(TASK_DELAY_INTERVAL);
        }
    }
}