using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisson : MonoBehaviour
{
    private void Start()
    {
        ScoreScript.instance.onplay.AddListener(ActivePlayer);
    }
    private void ActivePlayer()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);    
            ScoreScript.instance.GameOver();
        }
    }
}
