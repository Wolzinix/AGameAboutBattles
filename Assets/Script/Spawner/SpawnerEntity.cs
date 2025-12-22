using System.Collections;
using UnityEngine;

public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] GameObject _gm;

    [SerializeField] Transform _spawnPoint;
    void Start()
    {
        StartCoroutine(SpawnXTime());
    }

    void Update()
    {
    }

    IEnumerator SpawnXTime()
    {
        yield return new WaitForSeconds(2);

        Instantiate(_gm, _spawnPoint);
    }
}
