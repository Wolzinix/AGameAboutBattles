using System.Collections;
using System.Collections.Generic;
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
    private bool spawning = false;

    private GameObject _LastSpawned = null;

    public UnityEvent SpawnedEntity = new();

    private List<GameObject> listOfSpawning = new();
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
            AddToSpawn(_gm);
        }

        yield return null;
    }
    IEnumerator SpawnEntity()
    {
        while(spawning) 
        {
            yield return new WaitForSeconds(listOfSpawning[0].GetComponent<EntityManager>().TimeForApparition);
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