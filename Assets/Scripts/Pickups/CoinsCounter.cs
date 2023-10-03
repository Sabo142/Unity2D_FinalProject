using UnityEngine;
using TMPro;
public class CoinsCounter : MonoBehaviour
{
    public float coins = 0f;
    [SerializeField] private TMP_Text coinText;
    void Update()
    {
        coins += PlayerMovement.CoinCount;
        coinText.text = "Coins: " + ((int)coins).ToString();
    }
    public void addCoin(int coin)
    {
        coins += coin;
    }
}