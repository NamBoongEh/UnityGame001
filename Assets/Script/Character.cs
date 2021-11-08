using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jump;
    bool checkJump ;

    int score;
    public TextMesh scoreText;
    public SpriteRenderer[] speechBubble;

    public GameObject gameOverCurtain;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkJump = true;

        scoreText.text = "0";

        gameOverCurtain.gameObject.SetActive(false);
    }

    void Update()
    {

            if (Input.anyKey && checkJump)
            {
                Debug.Log("뛴다.");
                rigid.AddForce(Vector2.up * jump);
            }
    }

    private void FixedUpdate()
    {
        if (rigid.velocity.y <= 0)
        {
            //물체와 닿는지 확인하기위한 선
            Debug.DrawRay(rigid.position, Vector3.right, new Color(0, 1, 0));
            Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));
            Debug.DrawRay(rigid.position, Vector3.up, new Color(0, 0, 1));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitSky = Physics2D.Raycast(rigid.position, Vector3.up, 1, LayerMask.GetMask("PlatformSky"));
            RaycastHit2D rayHitCarrot = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Carrot"));

            //땅 충돌 이벤트
            if (rayHit.collider != null)
            {
                if (rayHit.distance <= 0.78f)
                    checkJump = true;
            }

            //하늘 충돌 이벤트
            if (rayHitSky.collider != null)
            {
                if (rayHitSky.distance <= 0.78f)
                    Debug.Log("하늘에 닿았다! " + rayHitSky.collider.name);
            }

            if(rayHitCarrot.collider != null)
            {
                if(rayHitCarrot.distance <= 0.78f)
                {
                    Debug.Log("당근에 올라탔다! " + rayHitCarrot.collider.name);
                    GameOver();
                }
            }
        }
        else
            checkJump = false;
    }

    // 점수
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            // a값이 기본적으로 0으로 고정
            // if문 들어왔을시 a가 255가 됨
            // 2초간 보여주고 다시 a는 0으로 만듬
            // 글자와 말풍선이 대상
            Invoke("ScoreText0", 2f);
            scoreText.color = Color.black;
            for (int i = 0; i < speechBubble.Length; i++)
                speechBubble[i].color = new Color(0.8349056f, 0.983357f, 1f, 1f);

            score = score + 10;
            Debug.Log("점수는 " + score);
            scoreText.text = score.ToString();
        }
    }

    void ScoreText0()
    {
        scoreText.color = Color.clear;
        for(int i=0; i<speechBubble.Length; i++)
        {
            speechBubble[i].color = new Color(0.8349056f, 0.983357f, 1f, 0f);
        }
    }

    void GameOver()
    {
        gameOverCurtain.gameObject.SetActive(true);
        Invoke("StopAll", 1.8f);
    }

    void StopAll()
    {
        Time.timeScale = 0;
    }
}
