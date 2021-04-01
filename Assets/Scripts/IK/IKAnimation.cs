using UnityEngine;

namespace AlexSpace
{
    [RequireComponent(typeof(Animator))]
    public sealed class IKAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animatorGO;
        [SerializeField] private Transform _LookObj;
        [SerializeField] private Transform _HandsObj;

        [SerializeField] private Transform _rightFoot;
        [SerializeField] private Transform _leftFoot;

        [SerializeField, Range(0f, 1f)] private float _handsWeight = 1;
        [SerializeField, Range(0f, 1f)] private float _lookWeight = 1;
        [SerializeField] bool ikActive;
        private RaycastHit rayHit;

        private void Start()
        {
            if (!_LookObj || !_HandsObj || !_rightFoot || !_leftFoot)
            {
                throw new System.Exception("Не добавлен компонент тела");
            }
            if (!_animatorGO)
            {
                throw new System.Exception("Не добавлен компонент аниматора");
            }
        }
        private void OnAnimatorIK(int layerIndex)
        {
            if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out rayHit, 2f))
            {
                _handsWeight = 1;
                _LookObj = _HandsObj = rayHit.transform;
            }
            if (ikActive)
            {
                if (_HandsObj)
                {
                    SetWeight(_handsWeight, AvatarIKGoal.LeftHand);
                    SetWeight(_handsWeight, AvatarIKGoal.RightHand);

                    SetIKPos(_HandsObj.position, AvatarIKGoal.RightHand);
                    SetIKRot(_HandsObj.rotation, AvatarIKGoal.RightHand);

                    SetIKPos(_HandsObj.position, AvatarIKGoal.LeftHand);
                    SetIKRot(_HandsObj.rotation, AvatarIKGoal.LeftHand);
                }
                if (_LookObj)
                {
                    _animatorGO.SetLookAtWeight(_lookWeight);
                    _animatorGO.SetLookAtPosition(_LookObj.position);
                }
            }
            else
            {
                SetWeight(0, AvatarIKGoal.RightHand);
            }
        }

        private void SetIKPos(Vector3 position, AvatarIKGoal body)
        {
            _animatorGO.SetIKPosition(body, position);
        }

        private void SetIKRot(Quaternion rotation, AvatarIKGoal body)
        {
            _animatorGO.SetIKRotation(body, rotation);
        }

        private void SetWeight(float weight, AvatarIKGoal body)
        {
            _animatorGO.SetIKPositionWeight(body, weight);
            _animatorGO.SetIKRotationWeight(body, weight);
        }
    }
}