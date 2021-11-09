using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    public SpriteRenderer coinSide1;
    public SpriteRenderer coinSide2;
  
    Transform coinTransform;
    public float speed;

    void Start()
    {
        coinTransform = GetComponent<Transform>();
        coin.gameObject.SetActive(true);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        if(coin.transform.position.x <= -15f)
            coin.transform.position = new Vector3(5f, -6.7f, -1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            coinSide1.material.color = Color.clear;
            coinSide2.material.color = Color.clear;
        }
    }
}
