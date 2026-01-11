using UnityEngine;

[RequireComponent (typeof(MovementEntity), typeof(EntityManager), typeof(AttackEntity))]
public class CollisionGestion : MonoBehaviour
{
    [HideInInspector] public EntityManager target;

    private MovementEntity m_Entity;
    private AttackEntity m_AttackEntity;
    public Animator animator;
    private void Start()
    {
        if(!target.GetComponent<MovementEntity>())
        {
            SearchTarget();
        }
    }
    public void Starting()
    {
        m_Entity = GetComponent<MovementEntity>();
        animator = GetComponentInChildren<Animator>();
        m_AttackEntity = GetComponent<AttackEntity>();
    }
    private GameObject RayCastForward()
    {
        Physics.Raycast(transform.position, transform.forward,out RaycastHit hit);
        return hit.collider ? hit.collider.gameObject : gameObject;
    }
    public void SetTarget(GameObject Target)
    {
        m_Entity.EndMoving.RemoveAllListeners();

        target = Target.GetComponent<EntityManager>();
        target.DeadEvent.AddListener(SearchTarget);

        SpawnerEntity spawner = target.GetComponent<SpawnerEntity>();
        if (spawner)
        {
            spawner.SpawnedEntity.AddListener(SearchTarget);
        }

        if (target.CompareTag(tag))
        {
            MovementEntity tm = target.GetComponent<MovementEntity>();
            if (tm)
            {
                tm.StartMoving.AddListener(m_Entity.ChangeIsMoving);
            }
        }
        else
        {
            m_Entity.EndMoving.AddListener(StartAttacking);
        }

        m_Entity.ChangeIsMoving();
    }
    public void SearchTarget()
    {
        if(target)
        {
            target.DeadEvent.RemoveListener(SearchTarget);
        }
        SetTarget(RayCastForward());
    }
    private void StartAttacking()
    {
        m_AttackEntity.StartAttack(target);
    }
    public bool IsMoving()
    {
        return m_Entity.IsItMoving();
    }
}