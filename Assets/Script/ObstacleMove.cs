using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    Transform cloudTransform;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        cloudTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
