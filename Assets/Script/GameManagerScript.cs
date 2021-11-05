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
        //���� ����
        if (Input.GetKey("escape"))
            Application.Quit();

        //10�� �̳� �����ð����� ���� ����
        currentTime += Time.deltaTime;

        if(currentTime > random)
        {
            GameObject copycoin = Instantiate(Coin);

            copycoin.transform.position = new Vector3(4.9f, 6.9f, -1f);
            currentTime = 0;
            random = Random.Range(1f, 10f);

            //20.5�� �ڿ� ������ ���� �ڵ� �Ҹ�
            Destroy(copycoin, 25f);
        }
    }
}
