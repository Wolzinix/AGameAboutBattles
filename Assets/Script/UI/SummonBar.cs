using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonBar : MonoBehaviour
{
    [SerializeField] SpawnerEntity spawnerPlayer;
    [SerializeField] TMP_Text numberOfSummon;
    [SerializeField] Image BarSpawn;
    private int numberOfSummons = 0;

    private int TimeForSpawn;

    private void Start()
    {
        spawnerPlayer.SpawnedEntity.AddListener(RemoveSummon);
        spawnerPlayer.AddEntityToSpawn.AddListener(AddSummon);
        spawnerPlayer.SpawnNewEntity.AddListener(StartSpawnBar);
    }
    private void OnDestroy()
    {
        spawnerPlayer.SpawnedEntity.RemoveListener(RemoveSummon);
        spawnerPlayer.AddEntityToSpawn.RemoveListener(AddSummon);
        spawnerPlayer.SpawnNewEntity.RemoveListener(StartSpawnBar);
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

    private void StartSpawnBar(int time)
    {
        TimeForSpawn = time;
        StartCoroutine(SpawnBarActualise());
    }

    IEnumerator SpawnBarActualise()
    {
        float timePassed = 0;
        while (timePassed < TimeForSpawn)
        {
            yield return new WaitForSeconds(0.1f);
            BarSpawn.fillAmount = timePassed / TimeForSpawn;
            timePassed += 0.1f;
        }
        BarSpawn.fillAmount = 0;
        yield return null;
    }

}
