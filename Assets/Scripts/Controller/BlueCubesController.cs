using System;

namespace AlexSpace
{
    public class BlueCubesController
    {
        public static event Action<int> _OnEndTrigger;

        public static void CallEvent(int value = 1)
        {
            _OnEndTrigger(value);
        }
    }
}