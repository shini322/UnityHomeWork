using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManage : MonoBehaviour
{
    private int _coinsCount = 0;

    public void AddCoins(int coins)
    {
        _coinsCount += coins;
    }
}
