using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update
  
    public TextMeshProUGUI TextTMPLife;
    public TextMeshProUGUI TextTMPCoin;
    public int life;
    public int coin;

    void Start()
    {
        TextTMPLife.text = "¡¿  " + life;
        if(coin<10)
            TextTMPCoin.text = "¡¿ 0" + coin;
        else
            TextTMPCoin.text = "¡¿ " + coin.ToString();
    }
}
