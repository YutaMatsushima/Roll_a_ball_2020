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
 
    void Start()
    {
        //時間間隔を決定する
        interval = 3f;
    }
 
    void Update()
    {
        //時間計測
        time += Time.deltaTime;
 
        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if(time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject target = Instantiate(targetPrefab);
            //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            target.transform.position = GetRandomPosition();
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
