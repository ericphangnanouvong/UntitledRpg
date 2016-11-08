using UnityEngine;
using System.Collections.Generic;

public class BaseEnemy {
    public string m_name;
    public int m_health;
    public int m_attack;
    public int m_magicAttack;
    public int m_defense;
    public int m_magicDefense;
    public Dictionary<string, BaseItem> m_LootTable;

   public BaseEnemy(string name, int health , int attack, int magicAttack, int defense, int magicDefense)
    {
        m_name = name;
        m_health = health;
        m_attack = attack;
        m_magicAttack = magicAttack;
        m_defense = defense;
        m_magicDefense = magicDefense;
    }
}
