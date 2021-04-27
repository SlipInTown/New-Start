using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexSpace
{
    public class BonusArrayController : IController,  IInitialization
    {
        public BadBonus[] _badCompArray;

        public bool[] _boolBadArray;

        public GoodBonus[] _goodCompArray;

        public bool[] _boolGoodArray;

        public PlayerBase _playerBase;

        public SavedData localData;

        public BonusArrayController(PlayerBase playerBase, SavedData data)
        {
            localData = data;

            _badCompArray = playerBase.badCompArray;

            _boolBadArray = new bool [_badCompArray.Length];

            for (int i = 0; i < _boolBadArray.Length; i++)
            {
                _boolBadArray.SetValue(_badCompArray[i].isActiveAndEnabled, i);
                _badCompArray[i].GetArray(this);
            }

            _goodCompArray = playerBase.goodCompArray;

            _boolGoodArray = new bool[_goodCompArray.Length];

            for (int i = 0; i < _boolGoodArray.Length; i++)
            {
                _boolGoodArray.SetValue(_goodCompArray[i].isActiveAndEnabled, i);
                _goodCompArray[i].GetArray(this);
            }
        }

        public void Initialization()
        {
            
        }
    }
}