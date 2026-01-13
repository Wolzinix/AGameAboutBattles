using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABrain : MonoBehaviour
{
    [SerializeField] SpawnerEntity SpawnerAllie;
    [SerializeField] SpawnerEntity SpawnerEnnemie;

    [SerializeField] List<GameObject> ListOfSpawnable = new List<GameObject>();
    private List<GameObject> ListOfEntityToSpawn = new List<GameObject>();

    void Start()
    {
        SpawnerAllie.ressourceManagerAllie.GoldUse.AddListener(SpawnTroupe);
        SpawnerEnnemie.SpawnNewEntityGM.AddListener(SpawnForCounter);
        StartCoroutine(SpawnSomething());
    }
    private void AddToListToSpawn(GameObject Entity)
    {
        ListOfEntityToSpawn.Add(Entity);
    }
    private void SpawnTroupe()
    {
        if(ListOfEntityToSpawn.Count > 0)
        {
            GameObject Entity = ListOfEntityToSpawn[0];
            if (Entity && SpawnerAllie.ressourceManagerAllie.GetGold() >= Entity.GetComponent<EntityManager>().GetCost())
            {
                ListOfEntityToSpawn.Remove(Entity);
                SpawnerAllie.AddToSpawn(Entity);
            }
        }
    }
    IEnumerator SpawnSomething()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            if(ListOfEntityToSpawn.Count < 5)
            {
                AddToListToSpawn(ListOfSpawnable[Random.Range(0, ListOfSpawnable.Count)]);
            }
        }
    }
    private void SpawnForCounter(GameObject Entity)
    {
        foreach(var i in ListOfSpawnable) 
        {
            if(i.GetComponent<EntityManager>().GetCost() == Entity.GetComponent<EntityManager>().GetCost())
            {
                AddToListToSpawn(i);
                break;
            }
        }
    }
}
