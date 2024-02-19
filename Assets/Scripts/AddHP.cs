using UnityEngine;

public class AddHP : MonoBehaviour
{
    [SerializeField] private GameObject potion;

    public Health health;
    private void Start()
     {
        health.GetComponent<Health>();
        potion.SetActive(false);
     }

    private void Update()
     {
        if (health.currentHP < 50)
        {
            potion.SetActive(true);
        }

        else
        {
            potion.SetActive(false);
        }
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            health.currentHP += 20;
            potion.gameObject.SetActive(false);
        }
    }
}
