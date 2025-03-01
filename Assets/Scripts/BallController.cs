using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public int force;
    public TMP_Text kiri;
    public TMP_Text kanan;
    public TMP_Text menang;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    public Image image;
    public TMP_Text mainLagi;




    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        
        

    }

    // Update is called once per frame
    void Update()

    {
        if (scoreP1 == 5 || scoreP2 == 5){
            if(Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("ahahaa");
                force = 500;
                menang.text = "";
                mainLagi.text = "";
                image.enabled = false;
                Vector2 arah = new Vector2 (2, 0).normalized;
                rigid.AddForce (arah * force);
                scoreP1 = 0;
                scoreP2 = 0;
                kanan.text = "0";
                kiri.text = "0";
            }
        
        }
            
    }

    private void OnCollisionEnter2D (Collision2D coll){
        if (coll.gameObject.name == "TepiKanan")
        {
            scoreP1 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2 (2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (coll.gameObject.name == "TepiKiri")
        {
            scoreP2 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2 (-2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2")
        {
            float sudut = (transform.position.y - coll.transform.position.y)*5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah*force*2);
        }
    }

    void ResetBall (){
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore(){
        kanan.text = scoreP2.ToString();
        kiri.text = scoreP1.ToString();
        Debug.Log("Score P1: "+scoreP1+" Score P2: "+scoreP2);
        if (scoreP1 == 5 ){
            force = 0;
            menang.text = "Player 1 Menang";
            image.enabled = true;
            mainLagi.text = "Press space to play again";

        }

        if (scoreP2 == 5 ){
            force = 0;
            image.enabled = true;
            menang.text = "Player 2 Menang";
            mainLagi.text = "Press space to play again";


        }

    }
}
