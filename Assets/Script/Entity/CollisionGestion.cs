using UnityEngine;

public class CollisionGestion : MonoBehaviour
{
    MovementEntity m_Entity;
    public bool IsAttacking;
    void Start()
    {
        m_Entity = GetComponent<MovementEntity>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (m_Entity)
        {
            if (!collision.CompareTag(tag))
            {
                m_Entity.ChangeIsMoving(false);
                IsAttacking = true;
            }
            else
            {
                CollisionGestion cg = collision.GetComponent<CollisionGestion>();
                if (cg && cg.IsAttacking)
                {
                    m_Entity.ChangeIsMoving(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (m_Entity)
        {
            m_Entity.ChangeIsMoving(true);
        }
    }
}
