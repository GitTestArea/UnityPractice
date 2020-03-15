using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0; //回転速度

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスが押されたら回転速度を設定する
        //0が左クリック,1が右クリック,2が真ん中クリック
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10;
        }

        //回転速度分ルーレットを回転させる
        transform.Rotate(0, 0, this.rotSpeed);

        //ルーレットを減速させる
        this.rotSpeed *= 0.96f;

    }
}
