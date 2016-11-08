using UnityEngine;
using System.Collections.Generic;

public class EnemyDatabase: MonoBehaviour{
    static public Dictionary<string, BaseEnemy> Enemies;
    // Use this for initialization
    void Start () {
        Enemies = new Dictionary<string, BaseEnemy>();
        BaseEnemy Enemy1 = new BaseEnemy("Zombie", 20, 5, 0, 0, 0);
        Enemies.Add("1", Enemy1);
    }
	
	
}
