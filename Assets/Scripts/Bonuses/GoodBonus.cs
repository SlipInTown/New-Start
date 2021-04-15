using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace AlexSpace
{
    public sealed class GoodBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private float _buffSpeed = 2f;
        private FirstPersonController _linkController;
        public void Effect()
        {
            _linkController.m_WalkSpeed += _buffSpeed;
            _linkController.m_RunSpeed += _buffSpeed * 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _linkController = other.GetComponent<FirstPersonController>();
            gameObject.SetActive(false);
            Effect();
        }
    }
}