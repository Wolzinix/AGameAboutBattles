using System.Collections;
using UnityEngine;

public class MovementEntity : MonoBehaviour
{
    [SerializeField] private float speed = 1;
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
            yield return new WaitForSeconds(0.1f * speed);
            transform.position += new Vector3(0, 0, 5f) * Time.deltaTime;
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
