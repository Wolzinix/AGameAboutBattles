using System.Collections;
using UnityEngine;

public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] GameObject _gm;

    [SerializeField] Transform _spawnPoint;
    [SerializeField] int TimeForSpawn = 2;
    private bool Spawn = true;
    void Start()
    {
        StartCoroutine(SpawnXTime());
    }

    IEnumerator SpawnXTime()
    {
        while(Spawn)
        {
            yield return new WaitForSeconds(TimeForSpawn);

            Instantiate(_gm, _spawnPoint);

        }
    }
}
