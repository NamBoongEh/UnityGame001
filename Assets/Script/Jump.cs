using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigid;
    public float jump;
    bool checkJump ;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        checkJump = true;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.anyKey && checkJump)
            {
                Debug.Log("뛴다.");
                rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
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
            RaycastHit2D rayHitSky = Physics2D.Raycast(rigid.position, Vector3.up, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHitCarrot = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Carrot"));

            //땅 충돌 이벤트
            if (rayHit.collider != null)
            {
                if (rayHit.distance <= 0.78f)
                {
                    Debug.Log(rayHit.collider.name);
                    checkJump = true;
                }
            }

            //하늘 충돌 이벤트
            if (rayHitSky.collider != null)
            {
                if (rayHitSky.distance <= 0.78f)
                {
                    Debug.Log("하늘에 닿았다! " + rayHitSky.collider.name);
                }
            }

            if(rayHitCarrot.collider != null)
            {
                if(rayHitCarrot.distance <= 0.78f)
                {
                    Debug.Log("당근에 올라탔다! " + rayHitCarrot.collider.name);
                }
            }
        }
        else
            checkJump = false;
    }

}
