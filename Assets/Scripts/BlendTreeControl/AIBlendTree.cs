using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class AIBlendTree : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private Animator animatorAI;
        [SerializeField] private string playerTag = "Player";
        private RaycastHit hit;
        [SerializeField,Range(0f, 1f)] private float blend = 0f;


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
                    if (hit.distance < 10)
                    {
                        blend += (Time.deltaTime * 0.25f);
                        animatorAI.SetFloat("Walk", Mathf.Clamp(blend, 0f, 1f));
                    }
                    else
                    {
                        blend -= (Time.deltaTime * 0.25f);
                        animatorAI.SetFloat("Walk", Mathf.Clamp(blend, 0f, 1f));
                    }
                }
                
                Debug.DrawRay(transform.position, hitDirection * distanceOfRay, Color.red);
            }

        }

    }
}
