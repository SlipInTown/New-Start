using System;
using UnityEngine;

namespace AlexSpace
{
    [Serializable]
    public class SavedData : IController,IInitialization
    {
        public bool[] _saveBadArray;

        public bool[] _saveGoodArray;

        public override string ToString()
        {
            string tempBad;

            tempBad = _saveBadArray[0].ToString();
            for (int i = 1; i < _saveBadArray.Length; i++)
            {
                tempBad += _saveBadArray[i].ToString();
            }

            string tempGood;

            tempGood = _saveGoodArray[0].ToString();
            for (int i = 1; i < _saveGoodArray.Length; i++)
            {
                tempGood += _saveGoodArray[i].ToString();
            }

            return $"{tempBad} {tempGood}";

        }

        public void ChangeBadState(bool state,int value)
        {
            _saveBadArray[value] = state;
        }

        public void ChangeGoodState(bool state, int value)
        {
            _saveGoodArray[value] = state;
        }

        public void Initialization()
        {

        }
    }
}