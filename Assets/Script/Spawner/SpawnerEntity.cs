using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EntityManager))]
public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] private GameObject _gm;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float TimeForSpawn = 3;
    private RessourceManager ressourceManagerEnnemie;
    private RessourceManager ressourceManagerAllie;

    public bool Spawn = true;

    private GameObject _LastSpawned = null;

    public UnityEvent SpawnEntity = new();
    void Start()
    {
        foreach(RessourceManager i in Resources.FindObjectsOfTypeAll(typeof(RessourceManager)))
        {
            if(!i.CompareTag(tag)){ ressourceManagerEnnemie = i;}
            else{  ressourceManagerAllie = i; }
        }
        StartCoroutine(SpawnXTime());
    }

    IEnumerator SpawnXTime()
    {
        while(Spawn)
        //for (int i = 0; i < 2; i++) 
        {
            yield return new WaitForSeconds(TimeForSpawn);
            GenerateEntity(_gm);
        }

        yield return null;
    }

    public void GenerateEntity(GameObject entity)
    {
        if (ressourceManagerAllie.RemoveGold(entity.GetComponent<EntityManager>().GetCost()))
        {
            GameObject instance = Instantiate(entity, _spawnPoint);

            instance.transform.rotation = transform.rotation;
            instance.tag = tag;

            instance.GetComponent<EntityManager>().ressourceManagerToGive = ressourceManagerEnnemie;

            CollisionGestion cgInstance = instance.GetComponent<CollisionGestion>();

            cgInstance.Starting();
            if (_LastSpawned) { cgInstance.SetTarget(_LastSpawned); }
            else { cgInstance.SearchTarget(); }
            _LastSpawned = instance;
            SpawnEntity.Invoke();
        }
    }
}
