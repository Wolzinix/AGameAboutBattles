using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangement : MonoBehaviour
{
    [SerializeField] int NumeroOfTheScene = 0;
    
    public void ChargeScene()
    {
        SceneManager.LoadScene(SceneIndex.GetSceneWithIndex(NumeroOfTheScene));
    }
}
