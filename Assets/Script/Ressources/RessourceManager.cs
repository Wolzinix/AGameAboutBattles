using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RessourceManager : MonoBehaviour
{
    [SerializeField] private int _Or;
    [SerializeField] bool SpawnRessources = true;

    [HideInInspector] public UnityEvent GoldUse = new();

    void Start()
    {
        StartCoroutine(GenerateGold());
    }
    IEnumerator GenerateGold()
    {
        while(SpawnRessources)
        {
            yield return new WaitForSeconds(1);
            AddGold(1);
        }
        yield return null;
    }

    public void AddGold(int gold)
    {
        _Or += gold;
        GoldUse.Invoke();
    }

    public int GetGold()
    {
        return _Or;
    }
}