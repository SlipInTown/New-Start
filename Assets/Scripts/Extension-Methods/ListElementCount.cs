using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListElementCount 
{
    public static Dictionary<T, int> ListElemCount<T>(this List<T> _list)
    {
        var tempDictionary = new Dictionary<T, int> { };

        int count;
        for (int i = 0; i < _list.Count; i++)
        {
            count = 0;
            T value = _list[i];

            for (int j = 0; j < _list.Count; j++)
            {
                if (_list[j].Equals(value))
                {
                    count++;
                }
            }

            tempDictionary.Add(value, count);
        }

        return tempDictionary;
    }
}
