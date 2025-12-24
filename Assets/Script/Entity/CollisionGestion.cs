using UnityEngine;

public class CollisionGestion : MonoBehaviour
{
    public bool IsAttacking;
    private MovementEntity m_Entity;
    private AttackEntity m_AttackEntity;
    public EntityManager target; 

    void Start()
    {
        m_Entity = GetComponent<MovementEntity>();
        m_AttackEntity = GetComponent<AttackEntity>();
        SetTarget();
    }

    private EntityManager RayCastForward()
    {
        Physics.Raycast(transform.position, transform.forward,out RaycastHit hit);
        EntityManager entityHit = hit.collider.GetComponent<EntityManager>();
        return entityHit;
    }

    private void SetTarget()
    {
        target = RayCastForward();
        if(target.CompareTag(tag))
        {
            MovementEntity tm = target.GetComponent<MovementEntity>();
            if (tm)
            {
                tm.StartMoving.AddListener(m_Entity.ChangeIsMoving);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (false)
        {
            CollisionGestion cg = collision.GetComponent<CollisionGestion>();
            if (!collision.CompareTag(tag))
            {
                m_Entity.ChangeIsMoving();
                IsAttacking = true;
                m_AttackEntity.StartAttack(collision.GetComponent<EntityManager>());
            }
            else
            {
                if (cg && cg.IsAttacking)
                {
                    m_Entity.ChangeIsMoving();
                }
            }
        }
    }
}
