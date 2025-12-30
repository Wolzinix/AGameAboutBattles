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
            yield return new WaitForSeconds(0.5f);
            AddGold(4);
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
    public bool RemoveGold(int gold)
    {
        if(gold <= _Or)
        {
            _Or -= gold;
            return true;
        }
        return false;
    }
}