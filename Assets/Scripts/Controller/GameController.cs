using UnityEngine;

namespace AlexSpace
{
    public class GameController : MonoBehaviour
    {
        private Controllers _controllers;



        private void Start()
        {
            _controllers = new Controllers();
            var tempBad = FindObjectsOfType<BadBonus>();

            bool[] tempBoolBad = new bool[tempBad.Length];

            for (int i = 0; i < tempBad.Length; i++)
            {
                tempBoolBad[i] = tempBad[i].isActiveAndEnabled;
            }

            var tempGood = FindObjectsOfType<GoodBonus>();

            bool[] tempBoolGood = new bool[tempGood.Length];

            for (int i = 0; i < tempBoolGood.Length; i++)
            {
                tempBoolGood[i] = tempGood[i].isActiveAndEnabled;
            }

            var tempBase = new PlayerBase(tempBoolBad, tempBoolGood, tempBad, tempGood);
            //var buttonData = FindObjectOfType<UnityEngine.UI.Button>();
            new GameInitialization(_controllers, tempBase);
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