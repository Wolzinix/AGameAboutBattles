using System.Collections;
using UnityEngine;

public class AttackEntity : MonoBehaviour
{
    private bool IsAttacking;
    private EntityManager manager;
    private EntityManager _target;
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
            if (CG.animator) { AnimationController.PlayAnimation((int)AnimationController.AnimType.Attack, CG.animator); }
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        IsAttacking = true;
        
        while (IsAttacking)
        {
            yield return new WaitForSeconds(1);
            if (CG.animator && !AnimationController.IsAttackingAnimation(CG.animator)) { AnimationController.PlayAnimation((int)AnimationController.AnimType.Attack, CG.animator); }

            if (_target) { _target.TakeDamage(manager.Attack); }
            if(!_target) { StopAttack(); }
        }
        yield return null;
    }
    public void StopAttack()
    {
        IsAttacking = false;

        if (CG.animator) { AnimationController.CancelAnimation(CG.animator); }
    }
}
