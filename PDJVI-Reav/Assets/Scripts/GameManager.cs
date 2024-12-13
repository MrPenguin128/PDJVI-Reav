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
        Debug.Log("Voc� coletou todas as moedas! Fim de jogo!");
        // Adicione l�gica de finaliza��o, como carregar outra cena ou mostrar uma tela de vit�ria
    }
}
