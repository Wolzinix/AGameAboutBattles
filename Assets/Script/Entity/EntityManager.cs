using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private float Hp = 3;
    [SerializeField] public float Attack = 2;
    [SerializeField] private float Defense = 0;

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        IsDead();
    }

    private void IsDead()
    {
        if (Hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
