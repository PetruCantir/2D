using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource coinAudio;
    [SerializeField] private Text finalScore;
    [SerializeField] private Text healthText;

    private int score = 0;
    
    public Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health != null && healthText != null)
        {
            healthText.text = health.currentHP.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            score++;
            scoreText.text = "Score: " + score;
            coinAudio.Play();
        }

        if ((health.currentHP <= 0) && collision.CompareTag("Respawn"))
        {
            finalScore.text = "Final Score:" + score.ToString();
        }
    }
}
