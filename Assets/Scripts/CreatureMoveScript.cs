using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureMoveScript : MonoBehaviour
{
    public CreatureScriptableObject creature;
    public string creatureName;
    public Sprite portrait;
    public int maxHealth;
    public int health;
    public int tempHealth;
    public string[] conditionName;
    public bool[] isActive;
    public bool isEnemy;
    public bool hasBossBar;

    private Vector3 dragOffset;
    private Camera mainCam;
    public GameObject[] gridObjects;
    public GameObject statsPanel;
    public StatsPanelScript StatsScript;

    private void Start()
    {
        statsPanel = GameObject.Find("Canvas");
        statsPanel =  statsPanel.transform.Find("StatsPanel").gameObject;
        StatsScript = statsPanel.GetComponent<StatsPanelScript>();

        //Set creature stats
        creatureName = creature.creatureName;
        portrait = creature.portrait;
        maxHealth = creature.maxHealth;
        health = creature.maxHealth;
        tempHealth = creature.tempHealth;
        conditionName = creature.conditionName;
        isActive = creature.isActive;
        isEnemy = creature;
        hasBossBar = creature.hasBossBar;
}

    //Drag and drop code
    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        StatsScript.TurnOff();
        transform.position = GetMousePos() + dragOffset;
    }

    private Vector3 GetMousePos()
    {
        var mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }


    //Release drag and drop code
    private void OnMouseUp()
    {
        transform.position = FindClosestGrid().transform.position;
    }

    private GameObject FindClosestGrid()
    {
        gridObjects = GameObject.FindGameObjectsWithTag("Grid");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject gameObject in gridObjects)
        {
            Vector3 diff = gameObject.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = gameObject;
                distance = curDistance;
            }
        }
        return closest;
    }


    //Show stats code
    private void OnMouseEnter()
    {
        //statsPanel.SetActive(true);
        StatsScript.currentCreature = this.gameObject;
        StatsScript.AssignVariables();
    }
    private void OnMouseExit()
    {
        //StatsScript.TurnOff();
    }
}
