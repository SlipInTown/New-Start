using System;

namespace AlexSpace
{
    public class BlueCubesController : IController
    {
        public static event Action<int> _OnEndTrigger;

        public static void CallEndEvent(int value = 1)
        {
            _OnEndTrigger(value);
        }

    }
}