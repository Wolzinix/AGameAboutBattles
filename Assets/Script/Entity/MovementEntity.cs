using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MovementEntity : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    public bool IsMoving = true;
    CollisionGestion CG;

    public UnityEvent StartMoving = new();

    void Start()
    {
        CG = GetComponent<CollisionGestion>();
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        yield return null;
        StartMoving.Invoke();
        while (IsMoving)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += Speed * Time.deltaTime * transform.forward;
            if (Vector3.Distance(CG.target.transform.position, transform.position) < 1)
            {
                IsMoving = false;
            }
        }
        yield return null;
    }

    public void ChangeIsMoving()
    {
        IsMoving = !IsMoving;
        if(IsMoving)
        {
            StartCoroutine(MoveForward());
        }
    }
}
