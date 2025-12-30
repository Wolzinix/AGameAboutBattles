using System.Collections;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    [SerializeField] private int _Or;
    [SerializeField] bool SpawnRessources = true;

    void Start()
    {
        StartCoroutine(GenerateGold());
    }
    IEnumerator GenerateGold()
    {
        while(SpawnRessources)
        {
            yield return new WaitForSeconds(1);
            _Or += 1;
        }
        yield return null;
    }

    public void AddGold(int gold)
    {
        _Or += gold;
    }
}