using TMPro;
using UnityEngine;

public class RessourceUI : MonoBehaviour
{
    [SerializeField] RessourceManager manager;
    [SerializeField] TMP_Text text;
    void Start()
    {
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
