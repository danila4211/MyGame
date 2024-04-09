using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int coins;
    public TMP_Text cointtext;
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Coin"))
        {
            coins++;
            cointtext.text = "Money: " + coins.ToString();
            Destroy(Collision.gameObject);
        }
    }
}
