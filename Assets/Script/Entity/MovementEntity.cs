using System.Collections;
using UnityEngine;

public class MovementEntity : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    public bool IsMoving = true; 
    void Start()
    {
        StartCoroutine(MoveForward());
    }

    IEnumerator MoveForward()
    {
        yield return null;
        while(IsMoving)
        {
            yield return new WaitForSeconds(0.01f);
            transform.position += Speed * Time.deltaTime * transform.forward;
        }
        yield return null;
    }

    public void ChangeIsMoving(bool isMoving)
    {
        IsMoving = isMoving;
        if(IsMoving)
        {
            StartCoroutine(MoveForward());
        }
    }
}
