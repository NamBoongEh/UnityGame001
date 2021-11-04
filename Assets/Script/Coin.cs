using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //x가 -15부터 밖, 시작은 5부터
    public GameObject coin;
  
    Transform coinTransform;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        coinTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        if(coin.transform.position.x <= -15f)
            coin.transform.position = new Vector3(5f, 6.7f, -7.8f);
    }
}
