using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerObjectScript : MonoBehaviour
{
    public CreatureScriptableObject creature;

    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI BossBarTxt;
    public Image image;

    public GameObject creatureObject;

    void Start()
    {
        image.sprite = creature.portrait;
        NameTxt.SetText("Name: " + creature.creatureName);
        HealthTxt.SetText("Health: " + creature.maxHealth.ToString());
        if (creature.hasBossBar)
        {
            BossBarTxt.SetText("Has Boss Bar: True");
        }
        else
        {
            BossBarTxt.SetText("Has Boss Bar: False");
        }
    }

    public void SpawnObject()
    {
        var creatureObj =  Instantiate(creatureObject);
        creatureObj.GetComponent<CreatureMoveScript>().creature = creature;
    }
}
