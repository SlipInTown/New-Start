using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        [SerializeField] private Animator animatorAI;
        [SerializeField] private string playerTag = "Player";
        private RaycastHit hit;
        


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            animatorAI = GetComponent<Animator>();


            agent.updateRotation = false;
	        agent.updatePosition = true;
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
                    Debug.Log(hit.distance);
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
