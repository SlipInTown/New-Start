using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace AlexSpace
{
    public class EndController
    {
        static int count = 0;
        static readonly int EndValue = 3;
        static readonly string SceneName = "New Start";
        private static void CheckValue()
        {
            if (count >= EndValue)
            {
                count = 0;
                SceneManager.LoadScene(SceneName);
            }
        }

        public static void AddValue()
        {
            count++;
            CheckValue();
            Log($"У вас {count} очков, до победы {EndValue - count}");
        }
    }
}