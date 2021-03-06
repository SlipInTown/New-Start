using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class AICharacterControl : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private Animator animatorAI;
        [SerializeField] private string playerTag = "Player";
        private RaycastHit hit;
        


        private void Start()
        {
            animatorAI = GetComponent<Animator>();
            animatorAI.applyRootMotion = true;
        }


        private void Update()
        {
            var distanceOfRay = 100;
            var hitDirection = (target.transform.position - transform.position).normalized;
            if (Physics.Raycast(transform.position, hitDirection, out hit))
            {
                if (hit.collider.CompareTag(playerTag))
                {
                    if (hit.distance > 10)
                    {
                        animatorAI.SetBool("Run", true);
                        animatorAI.SetBool("Walk", false);
                    }
                    else
                    {
                        animatorAI.SetBool("Run", false);
                        animatorAI.SetBool("Walk", true);
                    }
                }
                else
                {
                    animatorAI.SetBool("Run", false);
                    animatorAI.SetBool("Walk", false);
                }
                Debug.DrawRay(transform.position, hitDirection * distanceOfRay, Color.red);
            }
            
        }

    }
}
