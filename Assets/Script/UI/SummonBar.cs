using TMPro;
using UnityEngine;

public class SummonBar : MonoBehaviour
{
    [SerializeField] SpawnerEntity spawnerPlayer;
    [SerializeField] TMP_Text numberOfSummon;
    private int numberOfSummons = 0;

    private void Start()
    {
        spawnerPlayer.SpawnedEntity.AddListener(RemoveSummon);
        spawnerPlayer.AddEntityToSpawn.AddListener(AddSummon);
    }
    private void OnDestroy()
    {
        spawnerPlayer.SpawnedEntity.RemoveListener(RemoveSummon);

        spawnerPlayer.AddEntityToSpawn.RemoveListener(AddSummon);
    }

    private void RemoveSummon()
    {
        numberOfSummons--;
        numberOfSummon.text = numberOfSummons.ToString();
    }
    private void AddSummon()
    {
        numberOfSummons++;
        numberOfSummon.text = numberOfSummons.ToString();
    }

}
