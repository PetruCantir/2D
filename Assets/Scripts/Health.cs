using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Animator _anim;
    [SerializeField] private ParticleSystem _part;
    [SerializeField] private GameObject _gameOver;

    private int damage = 5;
    private bool isAlive;

    [HideInInspector]
    public int currentHP;

    private void Awake()
    {
        currentHP = health; 
        isAlive = true;
        _gameOver.SetActive(false);
    }

    private void CheckIsAlive()
    {
        if(currentHP > 0)
            isAlive = true;
       
        if (currentHP <= 0)
        {
            _gameOver.SetActive(true);
            Time.timeScale = 0f;
            isAlive = false;
            _anim.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            currentHP -= damage;
            _anim.SetTrigger("Hurt");
            _part.Play();
            Destroy(collision.gameObject);
            CheckIsAlive();
        }
       
        if(collision.CompareTag("Respawn"))
        {
           _gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
