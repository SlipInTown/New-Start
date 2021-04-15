using System;

namespace AlexSpace
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}