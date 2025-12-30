using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EntityManager))]
public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] private GameObject _gm;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int TimeForSpawn = 3;
    [SerializeField] private RessourceManager ressourceManagerEnnemie;


    public bool Spawn = true;

    private GameObject _LastSpawned = null;
    void Start()
    {
        foreach(RessourceManager i in Resources.FindObjectsOfTypeAll(typeof(RessourceManager)))
        {
            if(!i.CompareTag(tag))
            {
                ressourceManagerEnnemie = i;
            }
        }
        StartCoroutine(SpawnXTime());
    }

    IEnumerator SpawnXTime()
    {
        while(Spawn)
        //for (int i = 0; i < 2; i++) 
        {
            yield return new WaitForSeconds(TimeForSpawn);

            GameObject instance = Instantiate(_gm, _spawnPoint);

            instance.transform.rotation = transform.rotation;
            instance.tag = tag;

            instance.GetComponent<EntityManager>().ressourceManagerToGive = ressourceManagerEnnemie;

            CollisionGestion cgInstance = instance.GetComponent<CollisionGestion>();

            cgInstance.Starting();
            if (_LastSpawned) { cgInstance.SetTarget(_LastSpawned); }
            else { cgInstance.SearchTarget(); }
            _LastSpawned = instance;
        }

        yield return null;
    }
}
