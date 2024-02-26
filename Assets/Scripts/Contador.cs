using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Contador : MonoBehaviour
{
    public int Coins = 0;
    public int Goombas = 0;
    public Text CoinText;
    public Text GoombasText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScores();
     }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScores()
     {
        CoinText.text = "Coins   " + Coins;
        GoombasText.text = "Goombas   " + Goombas;
    }
    public void IncreaseCoins()
    {
        Coins++ ;
        UpdateScores();
    }
    public void IncreaseGoombas()
    {
        Goombas++ ;
        UpdateScores();
    }


}
