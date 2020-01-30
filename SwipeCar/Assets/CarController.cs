using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;

    // Start is called before the first frame update
    // Startは起動時に一回だけ実行されるもの
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスがクリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            this.speed = 0.2f; //初速度を設定
        }

        transform.Translate(this.speed, 0, 0); //移動 Translate(0,3,0)と書くことでY方向に3マス進む
        this.speed  *= 0.98f; //減速
    }
}
