using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
    }
}
