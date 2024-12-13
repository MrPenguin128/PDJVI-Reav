using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.OnCoinCollected();
            Destroy(gameObject); // Destroi a moeda
        }
    }
}
