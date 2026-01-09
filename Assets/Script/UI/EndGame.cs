using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] EntityManager playerBuilding;
    [SerializeField] EntityManager ennemieBuilding;

    [SerializeField] GameObject EndGameScreen;
    void OnEnable()
    {
        Time.timeScale = 1f;
        playerBuilding.DeadEvent.AddListener(EndGameSetUp);
        ennemieBuilding.DeadEvent.AddListener(EndGameSetUp);
    }

    public void EndGameSetUp()
    {
        EndGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
