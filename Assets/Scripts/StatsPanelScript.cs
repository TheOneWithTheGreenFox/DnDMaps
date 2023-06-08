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
    public GameObject currentCreature;
    private CreatureMoveScript creature;
    public GameObject EditMenu;
    public GameObject EditPanel;
    private bool lockMenuOpen = false;

    public void AssignVariables()
    {
        if (!lockMenuOpen)
        {
            creature = currentCreature.GetComponent<CreatureMoveScript>();

            NameTxt.SetText("Name: " + creature.creatureName);
            HealthTxt.SetText("Health: " + creature.health.ToString());
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

    public void ToggleEditMenu()
    {
        if (!lockMenuOpen)
        {
            EditPanel.GetComponent<EditManagerScript>().currentCreature = currentCreature;
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
