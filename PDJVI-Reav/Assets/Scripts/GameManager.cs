using UnityEditor;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int totalCoins;
    private int collectedCoins;

    void Start()
    {
        // Conta todas as moedas na cena
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        collectedCoins = 0;

    }


    public void OnCoinCollected()
    {
        collectedCoins++;
        Debug.Log($"Moedas coletadas: {collectedCoins}/{totalCoins}");

        if (collectedCoins >= totalCoins)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (SceneLoader.Instance.CurrentScene == 0)
            SceneLoader.Instance.LoadLevel(1);
        else
            SceneLoader.Instance.LoadLevel(0);
    }
}
