using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    private float coins = 0f;
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
