using UnityEngine;

public sealed class RagDollDIe : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rigidBodies;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private Animator animator;

    [SerializeField] private float lifeTime = 6f;
    private void Start()
    {
        if (!animator)
        {
            throw new System.Exception("Не добавлен аниматор");
        }

        if (rigidBodies.Length == 0)
        {
            throw new System.Exception("Не добавлены RigidBodies");
        }

        if (colliders.Length == 0)
        {
            throw new System.Exception("Не добавлены коллайдеры");
        }

        AliveMake();
    }

    private void RagDollState(bool active)
    {
        animator.enabled = !active;
        if (rigidBodies.Length != colliders.Length) return;
        for (int i = 0; i < rigidBodies.Length; i++)
        {
            rigidBodies[i].isKinematic = !active;

            colliders[i].enabled = active;
        }
    }

    private void AliveState(bool active)
    {
        animator.enabled = active;
        rigidBodies[0].isKinematic = !active;
        colliders[0].enabled = active;
    }

    private void RagDollMake()
    {
        RagDollState(true);
        AliveState(false);
    }
    private void AliveMake()
    {
        AliveState(true);
        RagDollState(false);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            RagDollMake();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            lifeTime = 5f;
            AliveMake();
        }
    }
}
