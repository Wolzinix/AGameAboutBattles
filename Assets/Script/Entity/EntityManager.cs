using UnityEngine;
using UnityEngine.Events;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private float Hp = 3;
    [SerializeField] public float Attack = 2;
    [SerializeField] private float Defense = 0;

    public UnityEvent DeadEvent = new();
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
            Destroy(gameObject);
            
            DeadEvent.Invoke();
        }
    }
}
