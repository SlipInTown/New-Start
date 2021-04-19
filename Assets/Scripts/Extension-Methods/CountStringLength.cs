using UnityEngine;

namespace AlexSpace
{
    public static class CountStringLength
    {
        public static void StringLength(this string abc)
        {
            Debug.Log($"Длина вашей строки = {abc.Length}");
        }
    }
}