using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EntityManager : MonoBehaviour
{
    private float maxHP;
    [SerializeField] private float Hp = 3;
    [SerializeField] private int Cost = 3;
    [SerializeField] private int Gold = 3;
    [SerializeField] public int TimeForApparition = 3;
    [SerializeField] private Image hpBar;

    [SerializeField] private GameObject RecompenseText;
    public float Attack = 2;
    public RessourceManager ressourceManagerToGive;

    [HideInInspector] public UnityEvent DeadEvent = new();
    private void Start()
    {
        maxHP = Hp;
        
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (hpBar)
        {
            hpBar.fillAmount = Hp / maxHP;
        }
        IsDead();
    }

    private void IsDead()
    {
        if (Hp < 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            if(ressourceManagerToGive)
            {
                ressourceManagerToGive.AddGold(Gold);
                if(RecompenseText)
                {
                    GameObject textToRecompense = Instantiate(RecompenseText);
                    textToRecompense.transform.position = transform.position;
                    textToRecompense.GetComponentInChildren<TMP_Text>().text = Gold.ToString();
                }
                

            }
            DeadEvent.Invoke();
            DeadEvent.RemoveAllListeners();
            Destroy(gameObject);
        }
    }

    public int GetCost()
    {
        return Cost;
    }
}