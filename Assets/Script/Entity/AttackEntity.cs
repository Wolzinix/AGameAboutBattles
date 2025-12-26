using System.Collections;
using UnityEngine;

public class AttackEntity : MonoBehaviour
{
    EntityManager manager;
    public bool IsAttacking;
    EntityManager _target;

    void Start()
    {
        manager = GetComponent<EntityManager>();
    }
    public void StartAttack(EntityManager target)
    {
        _target = target;
        if(!IsAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        yield return null;

        IsAttacking = true;
        while (IsAttacking) 
        {
            yield return new WaitForSeconds(1);
            if(_target )
            {
                _target.TakeDamage(manager.Attack);
            }
            else
            {
                IsAttacking = false;
            }
        }

        yield return null;
    }
    public void StopAttack()
    {
        IsAttacking = false;
    }
}
