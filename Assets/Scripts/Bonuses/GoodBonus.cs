using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace AlexSpace
{
    public sealed class GoodBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private float _buffSpeed = 2f;
        private FirstPersonController _linkController;

        private int _numberInArray;

        private BonusArrayController _bonusArray;
        public void Effect()
        {
            _linkController.m_WalkSpeed += _buffSpeed;
            _linkController.m_RunSpeed += _buffSpeed * 2;
        }

        public void GetArray(BonusArrayController bonusArray)
        {
            _bonusArray = bonusArray;

            var tempComponent = GetComponent<GoodBonus>();
            for (int i = 0; i < _bonusArray._goodCompArray.Length; i++)
            {
                if (tempComponent == _bonusArray._goodCompArray[i])
                {
                    _numberInArray = i;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _linkController = other.GetComponent<FirstPersonController>();

            ChangeState(_numberInArray);

            gameObject.SetActive(false);
            Effect();
        }

        private void ChangeState(int i)
        {
            _bonusArray._boolGoodArray.SetValue(false, i);
        }
    }
}