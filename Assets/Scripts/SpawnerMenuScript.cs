using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMenuScript : MonoBehaviour
{
    [SerializeField] private CreatureScriptableObject[] creatures;
    [SerializeField] private GameObject creaturePanel;

    private void Start()
    {
        creatures = Resources.LoadAll<CreatureScriptableObject>("ScriptableObjects/Creatures");

        for (int i = 0; i < creatures.Length; i++)
        {
            var creature = Instantiate(creaturePanel, gameObject.transform);
            creature.GetComponent<SpawnerObjectScript>().creature = creatures[i];
        }
    }


}
