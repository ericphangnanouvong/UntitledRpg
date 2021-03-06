﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public string monsterID;
    public int monsterSpeed;
    public TextMesh monsterName;
    public TextMesh monsterHp;
    public int currentHp;
    public int maxHealth;

    private Vector3 spawnPosition;
    private Vector3 newPosition;
    private bool moving = false;
    
    
    // Use this for initialization
    void Start () {
        BaseEnemy monster = EnemyDatabase.Enemies[monsterID];
        currentHp = monster.m_health;
        maxHealth = monster.m_health;
        spawnPosition = this.transform.position;
        monsterName.text = monster.m_name;
        monsterHp.text = "Hp: " + currentHp + "/" + monster.m_health;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (moving == false)
        {
            Invoke("Move", 5);
        }

        if (moving == true)
        {
            Invoke("MoveAgain", 5);
        }

        if(currentHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        float maxRandomRangeX = 50;
        float maxRandomRangeY = 50;
        float x = Random.Range(-maxRandomRangeX, maxRandomRangeX);
        float y = Random.Range(-maxRandomRangeY, maxRandomRangeY);
        if (moving == false)
        {
            newPosition = new Vector3(x, y, 0);
            newPosition += this.transform.position;
            moving = true;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, newPosition, Time.deltaTime * monsterSpeed); 
    }
    

    void MoveAgain()
    {
        moving = false;
    }
}
