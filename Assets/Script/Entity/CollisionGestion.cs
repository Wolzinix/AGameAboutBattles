using UnityEngine;

public class CollisionGestion : MonoBehaviour
{
    private MovementEntity m_Entity;
    private AttackEntity m_AttackEntity;
    public EntityManager target;

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
        m_AttackEntity = GetComponent<AttackEntity>();
    }

    private GameObject RayCastForward()
    {
        Physics.Raycast(transform.position, transform.forward,out RaycastHit hit);

        return hit.collider.gameObject;
    }

    public void SetTarget(GameObject Target)
    {
        m_Entity.ChangeIsMoving();
        m_Entity.EndMoving.RemoveAllListeners();

        target = Target.GetComponent<EntityManager>();
        target.DeadEvent.AddListener(SearchTarget);

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
    }
    public void SearchTarget()
    {
        if(target)
        {
            target.DeadEvent.RemoveAllListeners();
        }
        SetTarget(RayCastForward());
    }
    private void StartAttacking()
    {
        m_AttackEntity.StartAttack(target);
    }
}
