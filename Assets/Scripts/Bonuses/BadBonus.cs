using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace AlexSpace
{
    public sealed class BadBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private float debuff = -2f;
        private FirstPersonController link;
        public void Effect(Collider other)
        {
            link = other.GetComponent<FirstPersonController>();
            link.m_WalkSpeed += debuff;
            link.m_RunSpeed += debuff * 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            gameObject.SetActive(false);
            Effect(other);
        }
    }
}