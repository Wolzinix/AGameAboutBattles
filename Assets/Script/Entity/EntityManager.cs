using UnityEngine;
using UnityEngine.Events;

public class EntityManager : MonoBehaviour
{
    [SerializeField] private float Hp = 3;
    [SerializeField] private int Cost = 3;
    [SerializeField] private int Gold = 3;

    public float Attack = 2;
    public RessourceManager ressourceManagerToGive;

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
            if(ressourceManagerToGive)
            {
                ressourceManagerToGive.AddGold(Gold);
            }
            DeadEvent.Invoke();
            DeadEvent.RemoveAllListeners();
            Destroy(gameObject);
        }
    }

    public int GetCost()
    {
        return Cost;
    }
}