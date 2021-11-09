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
    public AudioSource audioMainSource; //배경음


    void Start()
    {
        audioMainSource = GetComponent<AudioSource>();

        random = Random.Range(1f, 10f);
        Time.timeScale = 0;
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

            //7.7초 뒤에 못먹은 코인 자동 소멸
            Destroy(copycoin, 7.7f);
        }

        if (gameOverCurtain.gameObject.activeSelf)
            Invoke("StopMusic", 0.5f);

    }

    //게임 재시작
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    //게임 시작
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
