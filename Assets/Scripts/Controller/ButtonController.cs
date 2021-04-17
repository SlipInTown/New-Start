using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AlexSpace
{
    public class ButtonController : MonoBehaviour,IController, IInitialization, ICleanup
    {

        public Button _button;

        public void Cleanup()
        {
            _button.onClick.RemoveAllListeners();
        }

        public ButtonController(Button data)
        {
            _button = data;
        }

        public void Initialization()
        {   
            _button.onClick.AddListener(CallEvent);
        }

        private void OnMouseDown()
        {
            Debug.Log("Работает!");
            BlueCubesController.CallEndEvent();
        }
        private void CallEvent()
        {
            Debug.Log("Работает!");
            BlueCubesController.CallEndEvent();
        }
    }
}