using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoonMove : MonoBehaviour
{
    public Transform sunrise;
    public Transform sunset;
    float journeyTime = 9000F;
    private float startTime;
    float reduceHeight = 10.0F; //Center���� ���̱�, �ش� ���� �������� �������� ���̴� ��������.

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = (sunrise.position + sunset.position) * 0.5F; //Center ����ŭ ���� �ö󰣴�.
        center -= new Vector3(0, 1f * reduceHeight, 0); //y���� ���̸� ���̰� ��������.
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }
}
