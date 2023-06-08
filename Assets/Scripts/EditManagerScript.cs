using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditManagerScript : MonoBehaviour
{
    private StatsPanelScript statsPanel;
    public TextMeshProUGUI NameTxt;
    public TextMeshProUGUI HealthTxt;
    public TextMeshProUGUI TempHealthTxt;
    public TextMeshProUGUI ConditionTxt;
    public int healthIncrement;
    public int tempHealthIncrement;
    public TextMeshProUGUI IncrementTxt;
    public TextMeshProUGUI TempIncrementTxt;
    public TMP_Dropdown conditionDropdown;
    public Toggle toggle;
    public GameObject currentCreature;
    private CreatureMoveScript creature;
    public List<string> activeConditions = new List<string>();

    private void OnEnable()
    {
        statsPanel = FindObjectOfType<StatsPanelScript>();

        creature = currentCreature.GetComponent<CreatureMoveScript>();

        NameTxt.SetText("Name: " + creature.creatureName);
        HealthTxt.SetText("Health: " + creature.health.ToString());
        TempHealthTxt.SetText("Temporary Health: " + creature.tempHealth.ToString());
        UpdateConditionList();
    }

    public void AddHealth(bool isTemp)
    {
        if (isTemp)
        {
            creature.tempHealth += tempHealthIncrement;
            TempHealthTxt.SetText("Temporary Health: " + creature.tempHealth.ToString());
        }
        else
        {
            creature.health += healthIncrement;
            if (creature.health > creature.maxHealth)
            {
                creature.health = creature.maxHealth;
            }
            HealthTxt.SetText("Health: " + creature.health.ToString());
        }
    }
    public void RemoveHealth(bool isTemp)
    {
        if (isTemp)
        {
            creature.tempHealth -= tempHealthIncrement;
            if (creature.tempHealth < 0)
            {
                creature.tempHealth = 0;
            }
            TempHealthTxt.SetText("Temporary Health: " + creature.tempHealth.ToString());
        }
        else
        {
            creature.health -= healthIncrement;
            if (creature.health < 0)
            {
                creature.health = 0;
            }
            HealthTxt.SetText("Health: " + creature.health.ToString());
        }
    }
    public void ChangeHealthIncrement(bool isTemp)
    {
        if (isTemp)
        {
            if (tempHealthIncrement == 1)
            {
                tempHealthIncrement = 10;
                TempIncrementTxt.SetText("10");
            }
            else if (tempHealthIncrement == 10)
            {
                tempHealthIncrement = 100;
                TempIncrementTxt.SetText("100");
            }
            else
            {
                tempHealthIncrement = 1;
                TempIncrementTxt.SetText("1");
            }
        }
        else
        {
            if (healthIncrement == 1)
            {
                healthIncrement = 10;
                IncrementTxt.SetText("10");
            }
            else if (healthIncrement == 10)
            {
                healthIncrement = 100;
                IncrementTxt.SetText("100");
            }
            else
            {
                healthIncrement = 1;
                IncrementTxt.SetText("1");
            }
        }
    }



    public void CheckCondition()
    {
        if (creature.isActive[conditionDropdown.value])
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void UpdateCondition()
    {
        if (!creature.isActive[conditionDropdown.value] && toggle.isOn)
        {
            creature.isActive[conditionDropdown.value] = true;
            UpdateConditionList();
        }
        else if (creature.isActive[conditionDropdown.value] && !toggle.isOn)
        {
            creature.isActive[conditionDropdown.value] = false;
            UpdateConditionList();
        }
        else
        {
            Debug.Log("Conditions already match");
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

    public void DestroyCreature()
    {
        Destroy(currentCreature);
        statsPanel.ToggleEditMenu();
    }
}
