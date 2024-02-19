using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("RespawnCoin", Random.Range(15f, 25f));
        }
    }

    private void RespawnCoin()
    {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.SetActive(true);
        coin.GetComponent<Collider2D>().enabled = true;
    }
}
