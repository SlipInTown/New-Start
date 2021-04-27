using System;
using UnityEngine;

namespace AlexSpace
{
    [Serializable]
    public class SavedData
    {
        public string _name;
        public Vector3Serializable _position;
        public bool _isEnabled;
        
        public override string ToString() => $"Name {_name} Position {_position} IsVisible {_isEnabled}";
    }

    [Serializable]
    public struct Vector3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3Serializable(float X,float Y,float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public static implicit operator Vector3(Vector3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vector3Serializable(Vector3 value)
        {
            return new Vector3Serializable(value.x, value.y, value.z);
        }

        public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";
    }
}