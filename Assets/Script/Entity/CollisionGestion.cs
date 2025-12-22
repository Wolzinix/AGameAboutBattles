using UnityEngine;

public class CollisionGestion : MonoBehaviour
{
    MovementEntity m_Entity;
    void Start()
    {
        m_Entity = GetComponent<MovementEntity>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (m_Entity)
        {
            m_Entity.ChangeIsMoving(false);

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
