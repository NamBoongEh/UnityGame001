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
    public AudioClip audioCoin;

    public GameObject gameOverCurtain;
    public GameObject restartBtn;
    public AudioSource audioSource; //���� ȿ����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        checkJump = true;

        scoreText.text = "0";

        gameOverCurtain.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.anyKey && checkJump)
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        if (rigid.velocity.y <= 0)
        {
            //��ü�� ����� Ȯ���ϱ����� ��
            Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitCarrot = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Carrot"));

            //�� �浹 �̺�Ʈ
            if (rayHit.collider != null)
            {
                if (rayHit.distance <= 0.78f)
                    checkJump = true;
            }

            if(rayHitCarrot.collider != null)
            {
                if(rayHitCarrot.distance <= 0.78f)
                    GameOver();
            }
        }
        else
            checkJump = false;
    }

    // ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            audioSource.clip = audioCoin;
            audioSource.Play();

            Invoke("ScoreText0", 2f);
            scoreText.color = Color.black;
            for (int i = 0; i < speechBubble.Length; i++)
                speechBubble[i].color = new Color(0.8349056f, 0.983357f, 1f, 1f);

            score = score + 10;
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
        restartBtn.gameObject.SetActive(false);
        Invoke("StopAll", 1.8f);
    }

    void StopAll()
    {
        restartBtn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
