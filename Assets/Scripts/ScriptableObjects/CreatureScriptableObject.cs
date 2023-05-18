using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CreatureScriptableObject : ScriptableObject
{
    public string creatureName;
    public Sprite portrait;
    public int maxHealth;
    public int health;
    public int tempHealth;
    public string[] conditionName;
    public bool[] isActive;
    public bool isEnemy;
    public bool hasBossBar;
}
