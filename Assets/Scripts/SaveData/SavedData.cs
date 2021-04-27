using System;
using UnityEngine;

namespace AlexSpace
{
    [Serializable]
    public class SavedData
    {
        public bool[] _saveBadArray;

        public bool[] _saveGoodArray;

        //public override string ToString()
        //{
        //    string temp;

        //    temp = _saveBadArray[0].ToString();
        //    for (int i = 1; i < _saveBadArray.Length; i++)
        //    {
        //        temp += _saveBadArray[i].ToString();
        //    }

        //    return temp;
        //}
    }
}