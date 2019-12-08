using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBank : MonoBehaviour
{
    public static PlayerBank instance;
    public int currentCoins;

    public float timerInBetween = 0.1f;

    public Text coinText;
    private void Awake()
    {
        instance = GetComponent<PlayerBank>();
    }

    public IEnumerator UpdateCoinText(int amount, int sign)
    {
        yield return null;
        if(sign > 0)
        {
            for (int i = 0; i < amount; i ++)
            {
                currentCoins ++;
                coinText.text = currentCoins.ToString();
                yield return new WaitForSeconds(timerInBetween);
            }
        }
        else
        {
            for (int i = -amount; i < 0; i++)
            {
                currentCoins--;
                coinText.text = currentCoins.ToString();
                Debug.Log(i);
                yield return new WaitForSeconds(timerInBetween);
            }
        }
        
    }
}
