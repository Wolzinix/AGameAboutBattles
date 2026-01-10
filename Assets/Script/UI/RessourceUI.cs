using TMPro;
using UnityEngine;

public class RessourceUI : MonoBehaviour
{
    [SerializeField] RessourceManager manager;
    [SerializeField] TMP_Text text;
    void Start()
    {
        foreach (RessourceManager i in FindSceneObjectsOfType(typeof(RessourceManager)))
        {
            if (i.CompareTag(tag)) { manager = i; break; }
        }

        manager.GoldUse.AddListener(ActualiseUI);
        ActualiseUI();
    }

    private void ActualiseUI()
    {
        text.text = manager.GetGold().ToString();
    }

    public RessourceManager GetRessourceManacer()
    {
        return manager;
    }
}
