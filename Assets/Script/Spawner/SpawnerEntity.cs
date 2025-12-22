using UnityEngine;

public class SpawnerEntity : MonoBehaviour
{
    [SerializeField] GameObject _gm;
    void Start()
    {
        
    }

    void Update()
    {
        Instantiate(_gm, transform);
    }
}
