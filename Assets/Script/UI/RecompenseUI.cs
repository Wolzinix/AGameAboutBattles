using System.Collections;
using UnityEngine;

public class RecompenseUI : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Delete());
    }
    IEnumerator Move()
    {
        while(true)
        {
            transform.position += new Vector3(0,0.1f,0);

            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Delete()
    {
        yield return new WaitForSeconds(3);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
