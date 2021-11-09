using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainCall : MonoBehaviour
{
    public GameObject moonCurtain;
    public GameObject sunCurtain;
    public GameObject moon;
    public GameObject sun;
    bool changeCurtain = true;

    public GameObject moonFakeCurtain;
    public GameObject sunFakeCurtain;

    void Start()
    {
        moonCurtain.gameObject.SetActive(false);
        sunCurtain.gameObject.SetActive(false);

        moonFakeCurtain.gameObject.SetActive(false);
        sunFakeCurtain.gameObject.SetActive(false);

        ChangeMoonCurtain();
    }

    void Update()
    {
        if (moon.gameObject.activeSelf && !changeCurtain)
            ChangeMoonCurtain();
        else if (sun.gameObject.activeSelf && changeCurtain)
            ChangeSunCurtain();
    }

    void ChangeMoonCurtain()
    {
        changeCurtain = true;

        moonFakeCurtain.gameObject.SetActive(false);
        sunFakeCurtain.gameObject.SetActive(true);

        moonCurtain.gameObject.SetActive(true);
        sunCurtain.transform.localPosition = new Vector3(0, 13f, 99);
        sunCurtain.gameObject.SetActive(false);

    }

    void ChangeSunCurtain()
    {
        changeCurtain = false;

        moonFakeCurtain.gameObject.SetActive(true);
        sunFakeCurtain.gameObject.SetActive(false);

        moonCurtain.transform.localPosition = new Vector3(0, 13f, 99);
        moonCurtain.gameObject.SetActive(false);
        sunCurtain.gameObject.SetActive(true);
    }
}