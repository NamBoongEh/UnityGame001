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
                Debug.Log("�ڴ�.");
                rigid.AddForce(Vector2.up * jump);
            }
    }

    private void FixedUpdate()
    {
        if (rigid.velocity.y <= 0)
        {
            //��ü�� ����� Ȯ���ϱ����� ��
            Debug.DrawRay(rigid.position, Vector3.right, new Color(0, 1, 0));
            Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));
            Debug.DrawRay(rigid.position, Vector3.up, new Color(0, 0, 1));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitSky = Physics2D.Raycast(rigid.position, Vector3.up, 1, LayerMask.GetMask("PlatformSky"));
            RaycastHit2D rayHitCarrot = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Carrot"));

            //�� �浹 �̺�Ʈ
            if (rayHit.collider != null)
            {
                if (rayHit.distance <= 0.78f)
                    checkJump = true;
            }

            //�ϴ� �浹 �̺�Ʈ
            if (rayHitSky.collider != null)
            {
                if (rayHitSky.distance <= 0.78f)
                    Debug.Log("�ϴÿ� ��Ҵ�! " + rayHitSky.collider.name);
            }

            if(rayHitCarrot.collider != null)
            {
                if(rayHitCarrot.distance <= 0.78f)
                {
                    Debug.Log("��ٿ� �ö�����! " + rayHitCarrot.collider.name);
                    GameOver();
                }
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
            // a���� �⺻������ 0���� ����
            // if�� �������� a�� 255�� ��
            // 2�ʰ� �����ְ� �ٽ� a�� 0���� ����
            // ���ڿ� ��ǳ���� ���
            Invoke("ScoreText0", 2f);
            scoreText.color = Color.black;
            for (int i = 0; i < speechBubble.Length; i++)
                speechBubble[i].color = new Color(0.8349056f, 0.983357f, 1f, 1f);

            score = score + 10;
            Debug.Log("������ " + score);
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
