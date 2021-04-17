using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AlexSpace
{
    public class PlayerSpeedController : IController, ICleanup, IInitialization
    {


        private PostProcessVolume _volumeProcess;

        public PlayerSpeedController()
        {

        }

        public void Cleanup()
        {
            throw new System.NotImplementedException();
        }

        public void Initialization()
        {
            throw new System.NotImplementedException();
        }
    }
}