using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    //구름은 x가 -11부터 밖, 11부터 시작
    Transform cloudTransform;
    public float speed;
    public GameObject[] cloudBox;
    public GameObject[] carrotBox;
    float random;

    void Start()
    {
        cloudTransform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        //구름1
        if(cloudBox[1].transform.localPosition.x <= -11f)
        {
            cloudBox[0].transform.localPosition = new Vector3(11f, 4.77f, 3f);
            cloudBox[1].transform.localPosition = new Vector3(12.21f, 4.47f, 3f);
        }
        //구름2
        else if(cloudBox[2].transform.localPosition.x <= -11f)
            cloudBox[2].transform.localPosition = new Vector3(11f, 3.23f, 3f);
        //구름3
        else if(cloudBox[3].transform.localPosition.x <= -11f)
            cloudBox[3].transform.localPosition = new Vector3(11f, 5.52f, 3f);
        //구름4
        else if(cloudBox[6].transform.localPosition.x <= -11f)
        {
            cloudBox[4].transform.localPosition = new Vector3(11f, 4.07f, 3f);
            cloudBox[5].transform.localPosition = new Vector3(11.64f, 4.31f, 3f);
            cloudBox[6].transform.localPosition = new Vector3(12.11f, 3.97f, 3f);
        }
        //구름5
        else if(cloudBox[7].transform.localPosition.x <= -11f)
            cloudBox[7].transform.localPosition = new Vector3(11f, 2.46f, 3f);


        if(carrotBox[0].transform.localPosition.x <= -23f)
        {
            random = Random.Range(0f, 90f);
            carrotBox[0].transform.localPosition = new Vector3(random, 0f, 0f);
            Debug.Log("1번 빠른 당근 거리 : " + random);
        }
        else if(carrotBox[1].transform.localPosition.x <= -23f)
        {
            random = Random.Range(12.26f, 20f);
            carrotBox[1].transform.localPosition = new Vector3(random, 0f, 0f);
            Debug.Log("2번 뚱뚱 당근 거리 : " + random);

        }
        else if(carrotBox[2].transform.localPosition.x <= -23f)
        {
            random = Random.Range(-3.3f, 25f);
            carrotBox[2].transform.localPosition = new Vector3(random, 1.62f, 0f);
            Debug.Log("3번 평범 당근 거리 : " + random);
        }
    }
}
