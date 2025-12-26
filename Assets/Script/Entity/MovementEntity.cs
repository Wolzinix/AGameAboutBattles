using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MovementEntity : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    public bool IsMoving = false;
    CollisionGestion CG;

    public UnityEvent StartMoving = new();
    public UnityEvent EndMoving = new();

    void Start()
    {
        CG = GetComponent<CollisionGestion>();
    }

    IEnumerator MoveForward()
    {
        yield return null;
        StartMoving.Invoke();
        while (IsMoving)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += Speed * Time.deltaTime * transform.forward;
            if(CG.target)
            {
                if (Vector3.Distance(CG.target.transform.position, transform.position) < 1)
                {
                    IsMoving = false;
                }
            }
        }
        EndMoving.Invoke();
        yield return null;
    }

    public void ChangeIsMoving()
    {
        if(!IsMoving)
        {
            IsMoving = true;
            StartCoroutine(MoveForward());
        }
    }
}
