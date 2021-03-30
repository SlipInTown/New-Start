using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace AlexSpace
{
    public sealed class GoodBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private float buff = 2f;
        private FirstPersonController link;
        public void Effect(Collider other)
        {
            link = other.GetComponent<FirstPersonController>();
            link.m_WalkSpeed += buff;
            link.m_RunSpeed += buff * 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            gameObject.SetActive(false);
            Effect(other);
        }
    }
}