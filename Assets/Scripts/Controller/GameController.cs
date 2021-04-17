using UnityEngine;

namespace AlexSpace
{
    public class GameController : MonoBehaviour
    {
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            var buttonData = FindObjectOfType<UnityEngine.UI.Button>();
            new GameInitialization(_controllers,buttonData);
            _controllers.Initialization();
        }
        private void Update()
        {
            _controllers.Execute();
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}