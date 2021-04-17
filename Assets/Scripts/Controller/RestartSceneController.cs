using System;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

namespace AlexSpace
{
    public class RestartSceneController : ICleanup, IInitialization, IController
    {
        private int _countOfLife = 0;
        private readonly int _endValue = 3;
        private readonly string _sceneName = "New Start";

        public void RestartScene()
        {
            SceneManager.LoadScene(_sceneName);
        }

        public void Initialization()
        {
            BlueCubesController._OnEndTrigger += AddValue;
        }

        private void AddValue(int value = 1)
        {
            _countOfLife += value;
            Log($"У вас {_countOfLife} очков, до победы {_endValue - _countOfLife}");
            if (_countOfLife >= _endValue)
            {
                RestartScene();
            }
        }

        public void Cleanup()
        {
            BlueCubesController._OnEndTrigger -= AddValue;
        }
    }
}