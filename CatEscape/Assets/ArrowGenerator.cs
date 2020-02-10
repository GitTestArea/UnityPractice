using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;  //変数の宣言
    float span = 1.0f;
    float delta = 0;    //経過時間
   
    void Update()
    {
        this.delta += Time.deltaTime; //Time.deltaTimeに前フレームと現在フレームの時間差が代入される
        if (this.delta > this.span) //60フレーム(1秒)経過したかの判定
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
