using System.Collections;
using UnityEngine;

public class AttackEntity : MonoBehaviour
{
    private bool IsAttacking;
    private EntityManager manager;
    [SerializeField] private EntityManager _target;
    private CollisionGestion CG;

    void Start()
    {
        manager = GetComponent<EntityManager>();

        CG = GetComponent<CollisionGestion>();
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
        IsAttacking = true;
        if (CG.animator) { AnimationController.PlayAnimation((int)AnimationController.AnimType.Attack, CG.animator); }

        while (IsAttacking)
        {
            yield return new WaitForSeconds(1);
            if(_target) { _target.TakeDamage(manager.Attack); }
            else { IsAttacking = false; }

        }

        if (CG.animator) { AnimationController.CancelAnimation(CG.animator); }
        yield return null;
    }
    public void StopAttack()
    {
        IsAttacking = false;
    }
}
