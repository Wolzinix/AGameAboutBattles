using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class MovementEntity : MonoBehaviour
{
    // Start is called before the first frame update
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
    }
}
