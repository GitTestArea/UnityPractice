using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");     
    }

    // Update is called once per frame
    void Update()
    {
        //フレームごとに等速で落下させる
        transform.Translate(0, -0.1f, 0);

        //画面外に出たらオブジェクトを破棄する
        if(transform.position.y < -5.0f)    //yが-5よりも小さくなったらオブジェクトを破棄する
        {
            Destroy(gameObject);
        }

        //当たり判定 p207ページ参照
        Vector2 p1 = transform.position;    //矢の中心座標をp1に代入している
        Vector2 p2 = this.player.transform.position;    //プレイヤーの中心座標をp2に代入している
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;    //矢の半径
        float r2 = 1.0f;    //プレイヤーの半径

        if (d < r1 + r2)
        {
            //監督スクリプトにプレイヤーと衝突したことを伝える
            //ArrowContorollerからGameDirectorオブジェクトがもつDecreaseHpメソッドを呼び出すためFindメソッドを使用して、GameDirectorオブジェクトを探している
            GameObject director = GameObject.Find("GameDirector");
            //GetComponentメソッドを使用してGameDirectorオブジェクトの持つGameDirectorスクリプトを取得し、DecreaseHpメソッドを呼び出しています。
            director.GetComponent<GameDirector>().DecreaseHp();

            //衝突した場合は矢を消す
            Destroy(gameObject);
        }
    }
}
