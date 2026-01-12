using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EntityManager))]
public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] private GameObject EntitySpawnForIA;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float TimeForSpawn = 3;
   
    public bool InfinitSpawn = true;

    [HideInInspector] public UnityEvent SpawnedEntity = new();
    [HideInInspector] public UnityEvent AddEntityToSpawn = new();
    [HideInInspector] public UnityEvent<int> SpawnNewEntity = new();

    private bool spawning = false;
    private GameObject _LastSpawned = null;
    private List<GameObject> listOfSpawning = new();
    private RessourceManager ressourceManagerEnnemie;
    private RessourceManager ressourceManagerAllie;

    void Start()
    {
        foreach(RessourceManager i in FindSceneObjectsOfType(typeof(RessourceManager)))
        {
            if(!i.CompareTag(tag)){ ressourceManagerEnnemie = i;}
            else{  ressourceManagerAllie = i; }
        }
        StartCoroutine(SpawnXTime());
    }
    IEnumerator SpawnXTime()
    {
        while(InfinitSpawn)
        //for (int i = 0; i < 2; i++) 
        {
            yield return new WaitForSeconds(TimeForSpawn);
            AddToSpawn(EntitySpawnForIA);
        }

        yield return null;
    }
    IEnumerator SpawnEntity()
    {
        while(spawning) 
        {
            int timeForSpawn = listOfSpawning[0].GetComponent<EntityManager>().TimeForApparition;
            SpawnNewEntity.Invoke(timeForSpawn);
            yield return new WaitForSeconds(timeForSpawn);
            GenerateEntity(listOfSpawning[0]);
            RemoveFirstFromList();
        }
        yield return null;
    }
    public void AddToSpawn(GameObject entity)
    {
        if (ressourceManagerAllie.RemoveGold(entity.GetComponent<EntityManager>().GetCost()))
        {
            listOfSpawning.Add(entity);
            AddEntityToSpawn.Invoke();


            if (!spawning)
            {
                spawning = true;
                StartCoroutine(SpawnEntity());
            }
        }
    }

    private void RemoveFirstFromList()
    {
        listOfSpawning.RemoveAt(0);
        if (listOfSpawning.Count == 0)
        {
            spawning = false;
        }
    }
    public void GenerateEntity(GameObject entity)
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
        SpawnedEntity.Invoke();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}