using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 20; // 動く速さ
    private Rigidbody rb; // Rididbody
    private int targetnum = 0;
    public Text score;
    public Text Result;
    private float time;
    private float oldtime;
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
        time = 0;
        Result.text = "";
    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        if(targetnum < 10){
            time += Time.deltaTime;
            if((int)time != (int)oldtime){
                score.text = "Time: " + ((int)time).ToString();
            }
            oldtime = time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("target"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);
            targetnum++;
            if(targetnum >= 10){
                score.text = "Time: " + ((int)oldtime).ToString();
                Result.text = "Clear!!";
            }
        }
    }
}
