﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

namespace AlexSpace
{
    public sealed class BadBonus : MonoBehaviour, IBonus
    {
        [SerializeField] private PostProcessVolume _volumeProcess;

        private Shake _shakeClass;

        [SerializeField] private static bool _isState = false;

        [SerializeField] private float _debuffSpeed = -2f;

        private FirstPersonController _linkController;
        private BonusArrayController _bonusArray;
        private int _numberInArray;

        private void Start()
        {
            _shakeClass = new Shake();
            if (!_volumeProcess)
            {
                _volumeProcess = FindObjectOfType<PostProcessVolume>();
            }
            _shakeClass._myEvent += MakeGlobal;
        }

        public void GetArray(BonusArrayController bonusArray)
        {
            _bonusArray = bonusArray;

            var tempComponent = GetComponent<GoodBonus>();
            for (int i = 0; i < _bonusArray._badCompArray.Length; i++)
            {
                if (tempComponent == _bonusArray._badCompArray[i])
                {
                    _numberInArray = i;
                }
            }
        }

        public void Effect()
        {
            _isState = !_isState;
            MakeGlobal(_isState);
            _linkController.m_WalkSpeed += _debuffSpeed;
            _linkController.m_RunSpeed += _debuffSpeed * 2;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            _linkController = other.GetComponent<FirstPersonController>();

            ChangeState(_numberInArray);

            gameObject.SetActive(false);
            Effect();
        }

        private void MakeGlobal(bool state)
        {
            _volumeProcess.isGlobal = state;
        }

        private void ChangeState(int i)
        {
            _bonusArray._boolBadArray.SetValue(false, i);
        }
    }
}