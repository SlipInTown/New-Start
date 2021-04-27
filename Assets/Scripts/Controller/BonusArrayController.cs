using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexSpace
{
    public class BonusArrayController : IController, IExecute, IInitialization
    {
        public BadBonus[] _badArray;

        public bool[] _helpBadArray;

        public GoodBonus[] _goodArray;

        public bool[] _helpGoodArray;

        public EndBonus[] _endArray;

        public bool[] _helpEndArray;

        public BonusArrayController(BadBonus[] badtemp, GoodBonus[] goodtemp, EndBonus[] endtemp)
        {
            _badArray = badtemp;

            _helpBadArray = new bool [badtemp.Length];

            _goodArray = goodtemp;

            _helpGoodArray = new bool[goodtemp.Length];

            _endArray = endtemp;

            _helpEndArray = new bool[endtemp.Length];
        }

        public void Execute()
        {
            
        }

        public void Initialization()
        {
            
        }
    }
}