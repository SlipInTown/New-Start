using UnityEngine;

namespace AlexSpace
{
    public sealed class EndBonus : MonoBehaviour, IBonus
    {
        public void Effect(Collider other)
        {
            EndController.AddValue();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            gameObject.SetActive(false);
            Effect(other);
        }
    }
}