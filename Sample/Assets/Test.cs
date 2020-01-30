using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int hp = 100;
    private int power = 50;

    public void Attack()
    {
        Debug.Log(this.power + "のダメージを与えた");
    }

    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log(damage + "のダメージを与えた");
    }
}

public class Test : MonoBehaviour
{
    void Start()
    {
        Player myPlayer = new Player();
        myPlayer.Attack();
        myPlayer.Damage(30);

        Vector2 playerPos = new Vector2(3.0f, 4.0f);
        playerPos.x += 8.0f;
        playerPos.y += 5.0f;
        Debug.Log(playerPos);

    }

    void Update()
    {
        
    }
}
