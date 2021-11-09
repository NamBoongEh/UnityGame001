using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Coin;
    float currentTime;
    float random;

    public GameObject gameStartCurtain;
    public GameObject gameOverCurtain;
    public AudioSource audioMainSource; //�����


    void Start()
    {
        audioMainSource = GetComponent<AudioSource>();

        random = Random.Range(1f, 10f);
        Time.timeScale = 0;
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

            //7.7�� �ڿ� ������ ���� �ڵ� �Ҹ�
            Destroy(copycoin, 7.7f);
        }

        if (gameOverCurtain.gameObject.activeSelf)
            Invoke("StopMusic", 0.5f);

    }

    //���� �����
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    //���� ����
    public void StartGame()
    {
        gameStartCurtain.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void StopMusic()
    {
        audioMainSource.Stop();
    }
}
