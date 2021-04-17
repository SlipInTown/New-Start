using UnityEngine;

namespace AlexSpace
{
    public sealed class EndBonus : MonoBehaviour, IBonus
    {
        public void Effect()
        {
            BlueCubesController.CallEndEvent();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            gameObject.SetActive(false);
            Effect();
        }
    }
}