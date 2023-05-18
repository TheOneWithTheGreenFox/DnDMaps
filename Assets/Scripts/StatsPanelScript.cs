using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPanelScript : MonoBehaviour
{
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI TempHealthTxt;
    public TextMeshProUGUI ConditionTxt;
    public List<string> activeConditions = new List<string>();
    public CreatureScriptableObject creature;
    public GameObject EditMenu;
    private bool lockMenuOpen = false;

    public void AssignVariables(CreatureScriptableObject creatureObject)
    {
        if (!lockMenuOpen)
        {
            creature = creatureObject;
            NameTxt.SetText("Name: " + creatureObject.name);
            HealthTxt.SetText("Health: " + creatureObject.health.ToString());
            TempHealthTxt.SetText("Temporary Health: " + creature.tempHealth.ToString());
            UpdateConditionList();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleEditMenu();
        }
    }

    private void ToggleEditMenu()
    {
        if (!lockMenuOpen)
        {
            EditMenu.SetActive(true);
            lockMenuOpen = true;
        }
        else
        {
            EditMenu.SetActive(false);
            lockMenuOpen = false;
            gameObject.SetActive(false);
        }
        
    }

    public void UpdateConditionList()
    {
        activeConditions.Clear();

        for (int i = 0; i < creature.conditionName.Length; i++)
        {
            if (creature.isActive[i] == true)
            {
                activeConditions.Add(creature.conditionName[i]);
            }
        }

        string conditionString = "Conditions: ";

        for (int i = 0; i < activeConditions.Count; i++)
        {
            conditionString = conditionString + activeConditions[i] + ", ";
        }

        ConditionTxt.SetText(conditionString);
    }

    public void TurnOff()
    {
        if (!lockMenuOpen)
        {
            gameObject.SetActive(false);
        }
    }
}
