using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Coin;
    float currentTime;
    float random;

    void Start()
    {
        random = Random.Range(1f, 10f);
    }

    void Update()
    {
        //게임 종료
        if (Input.GetKey("escape"))
            Application.Quit();

        //10초 이내 랜덤시간으로 코인 생성
        currentTime += Time.deltaTime;

        if(currentTime > random)
        {
            GameObject copycoin = Instantiate(Coin);

            copycoin.transform.position = new Vector3(4.9f, 6.9f, -1f);
            currentTime = 0;
            random = Random.Range(1f, 10f);

            //20.5초 뒤에 못먹은 코인 자동 소멸
            Destroy(copycoin, 25f);
        }
    }
}
