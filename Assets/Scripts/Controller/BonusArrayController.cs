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

        public BonusArrayController(BadBonus[] badtemp, GoodBonus[] goodtemp)
        {
            _badCompArray = badtemp;

            _boolBadArray = new bool [badtemp.Length];

            for (int i = 0; i < _boolBadArray.Length; i++)
            {
                _boolBadArray.SetValue(_badCompArray[i].isActiveAndEnabled, i);
                _badCompArray[i].GetArray(this);
            }

            _goodCompArray = goodtemp;

            _boolGoodArray = new bool[goodtemp.Length];

            for (int i = 0; i < _boolGoodArray.Length; i++)
            {
                _boolGoodArray.SetValue(_goodCompArray[i].isActiveAndEnabled, i);
                _goodCompArray[i].GetArray(this);
            }

            _playerBase = new PlayerBase(_boolBadArray, _boolGoodArray, _badCompArray, _goodCompArray);
        }

        public void Initialization()
        {
            
        }
    }
}