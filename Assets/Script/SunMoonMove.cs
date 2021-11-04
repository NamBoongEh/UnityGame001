using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonMove : MonoBehaviour
{
    public Transform sunrise;
    public Transform sunset;
    float journeyTime = 24000F;
    float startTime;
    float reduceHeight = 10.0F; //Center값을 줄이기, 해당 값이 높을수록 포물선의 높이는 낮아진다.

    public GameObject sun;
    public GameObject moon;
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        sun.gameObject.SetActive(false);
        moon.gameObject.SetActive(false);

        ChangeMoon();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = (sunrise.position + sunset.position) * 0.5F; //Center 값만큼 위로 올라간다.
        center -= new Vector3(0, 1f * reduceHeight, 0); //y값을 높이면 높이가 낮아진다.
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;

        if(transform.position.x <= -10.8f && transform.position.y <= -5.7)
        {
            Debug.Log("해또는 달 도착!");
            if (sun.gameObject.activeSelf)
                ChangeMoon();
            else if(moon.gameObject.activeSelf)
                ChangeSun();
        }
    }

    void ChangeSun()
    {
        Debug.Log("해로 바뀌었다!");
        startTime = Time.time;
        sun.gameObject.SetActive(true);
        moon.transform.position = new Vector3(9.96f, -5.43f, 10);
        moon.gameObject.SetActive(false);
    }

    void ChangeMoon()
    {
        Debug.Log("달로 바뀌었다!");
        startTime = Time.time;
        moon.gameObject.SetActive(true);
        sun.transform.position = new Vector3(9.96f, -5.43f, 10);
        sun.gameObject.SetActive(false);
    }

}
