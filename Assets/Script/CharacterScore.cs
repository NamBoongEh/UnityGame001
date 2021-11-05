using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScore : MonoBehaviour
{
    int score;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            score = score + 10;

            Debug.Log("Á¡¼ö´Â " + score);
        }
    }
}
