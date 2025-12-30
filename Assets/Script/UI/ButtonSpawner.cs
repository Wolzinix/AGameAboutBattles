using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : Button
{
    [SerializeField] GameObject entityToSpawn;
    [SerializeField] RessourceUI ressourceUI;
    protected override void Start()
    {
        ressourceUI = (RessourceUI)FindAnyObjectByType(typeof(RessourceUI));
        onClick.AddListener(SpawnEntity);
    }

    private void SpawnEntity()
    {
        ressourceUI.GetRessourceManacer().GetComponent<SpawnerEntity>().GenerateEntity(entityToSpawn);
    }

}
