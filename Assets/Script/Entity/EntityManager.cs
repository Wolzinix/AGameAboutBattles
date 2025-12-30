using UnityEngine;
using UnityEngine.Events;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private float Hp = 3;
    public float Attack = 2;

    [HideInInspector] public UnityEvent DeadEvent = new();
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        IsDead();
    }

    private void IsDead()
    {
        if (Hp < 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            DeadEvent.Invoke();
            Destroy(gameObject);
            
        }
    }
}
