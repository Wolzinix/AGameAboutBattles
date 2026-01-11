using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MovementEntity : MonoBehaviour
{
    [SerializeField] private float Speed = 5;

    [HideInInspector] private bool IsMoving = false;
    [HideInInspector] public UnityEvent StartMoving = new();
    [HideInInspector] public UnityEvent EndMoving = new();

    private CollisionGestion CG;
    
    void Start()
    {
        CG = GetComponent<CollisionGestion>();
        GetComponent<EntityManager>().DeadEvent.AddListener(StopEverything);
    }
    IEnumerator MoveForward()
    {
        while(CG && 
            CG.target && 
            CG.target.CompareTag(gameObject.tag) && 
            Vector3.Distance(CG.target.transform.position, transform.position) < 1f)
        {
            yield return new WaitForSeconds(0.5f);
        }
            
        StartMoving.Invoke();
        if (CG.animator)
        {
            AnimationController.PlayAnimation((int)AnimationController.AnimType.Move, CG.animator);
        }
        while (IsMoving)
        {
            if(CG.animator && !AnimationController.IsMovingAnimation(CG.animator))
            {
                AnimationController.PlayAnimation((int)AnimationController.AnimType.Move, CG.animator);
            }
            yield return new WaitForSeconds(0.01f);
            transform.position += Speed * Time.deltaTime * transform.forward;
            if(CG.target)
            {
                if (Vector3.Distance(CG.target.transform.position, transform.position) < 1f)
                {
                    IsMoving = false; 
                }
            }
        }
        if (CG.animator)
        {
            AnimationController.CancelAnimation(CG.animator);
        }
        EndMoving.Invoke();
        
        yield return null;
    }
    public void ChangeIsMoving()
    {
        if(!CG) { CG = GetComponent<CollisionGestion>(); }
        if(!IsMoving)
        {
            IsMoving = true;

            StartCoroutine(MoveForward());
        }
    }
    public bool IsItMoving()
    {
        return IsMoving;
    }
    public void StopEverything()
    {
        StopAllCoroutines();
    }
}