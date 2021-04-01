using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace AlexSpace
{
    public class EndController
    {
        static int _countOfLife = 0;
        static readonly int _endValue = 3;
        static readonly string _sceneName = "New Start";
        private static void CheckValue()
        {
            if (_countOfLife >= _endValue)
            {
                _countOfLife = 0;
                SceneManager.LoadScene(_sceneName);
            }
        }

        public static void AddValue()
        {
            _countOfLife++;
            CheckValue();
            Log($"У вас {_countOfLife} очков, до победы {_endValue - _countOfLife}");
        }
    }
}