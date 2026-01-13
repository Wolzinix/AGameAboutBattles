using System.Collections;
using UnityEngine;

public class AttackEntity : MonoBehaviour
{
    private bool IsAttacking;
    private EntityManager manager;
    private EntityManager _target;
    private CollisionGestion CG;

    [SerializeField] AudioClip attackSoundClip;

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
            CG.audioSource.clip = attackSoundClip;
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        IsAttacking = true;
        while (IsAttacking)
        {
            CG.audioSource.Play();
            yield return new WaitForSeconds(1);
            if (CG.animator && !AnimationController.IsAttackingAnimation(CG.animator)) { AnimationController.PlayAnimation((int)AnimationController.AnimType.Attack, CG.animator); }

            if (_target) { _target.TakeDamage(manager.Attack); }
            if (!_target) { StopAttack(); }
        }
        
        yield return null;
    }
    public void StopAttack()
    {
        IsAttacking = false;
        CG.audioSource.Stop();
        if (CG.animator) { AnimationController.CancelAnimation(CG.animator); }
    }
}
