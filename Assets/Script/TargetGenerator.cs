using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    //Targetプレハブ
    public GameObject targetPrefab;
    public float minPos = -4.5f;
    public float maxPos = 4.5f;
    //target生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    private int count = 0;
 
    void Start()
    {
        //時間間隔を決定する
        interval = 2f;
    }
 
    void Update()
    {
        //時間計測
        time += Time.deltaTime;
 
        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if(time > interval && count < 10)
        {
            //targetをインスタンス化する(生成する)
            GameObject target = Instantiate(targetPrefab);
            //生成したtargetの座標を決定する
            target.transform.position = GetRandomPosition();
            count++;
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
        }
    }


    private Vector3 GetRandomPosition(){
        float x = Random.Range(minPos, maxPos);
        float y = 0.4f;
        float z = Random.Range(minPos, maxPos);

        return new Vector3(x, y, z);
    }
}
