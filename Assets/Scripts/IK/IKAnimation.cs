using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;
    [SerializeField] private Transform LookObj;
    [SerializeField] private Transform HandsObj;

    [SerializeField] private Transform rightFoot;
    [SerializeField] private Transform leftFoot;

    [SerializeField, Range(0f, 1f)] private float handsWeight = 1;
    [SerializeField, Range(0f, 1f)] private float lookWeight = 1;
    [SerializeField] bool ikActive;
    private RaycastHit rayHit;
    private void OnAnimatorIK(int layerIndex)
    {
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out rayHit,2f))
        {
            handsWeight = 1;
            LookObj = HandsObj = rayHit.transform;
        }
        if (ikActive)
        {
            if (HandsObj)
            {
                SetWeight(handsWeight, AvatarIKGoal.LeftHand);
                SetWeight(handsWeight,AvatarIKGoal.RightHand);

                SetIKPos(HandsObj.position, AvatarIKGoal.RightHand);
                SetIKRot(HandsObj.rotation, AvatarIKGoal.RightHand);

                SetIKPos(HandsObj.position, AvatarIKGoal.LeftHand);
                SetIKRot(HandsObj.rotation, AvatarIKGoal.LeftHand);
            }
            if (LookObj)
            {
                animatorGO.SetLookAtWeight(lookWeight);
                animatorGO.SetLookAtPosition(LookObj.position);
            }
        }
        else
        {
            SetWeight(0, AvatarIKGoal.RightHand);
        }
    }

    private void SetIKPos(Vector3 position, AvatarIKGoal body)
    {
        animatorGO.SetIKPosition(body, position);
    }

    private void SetIKRot(Quaternion rotation, AvatarIKGoal body)
    {
        animatorGO.SetIKRotation(body, rotation);
    }

    private void SetWeight(float weight, AvatarIKGoal body)
    {
        animatorGO.SetIKPositionWeight(body, weight);
        animatorGO.SetIKRotationWeight(body, weight);
    }
}
