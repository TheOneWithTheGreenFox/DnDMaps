using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitChangerScript : MonoBehaviour
{
    public CreatureScriptableObject creature;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        creature = GetComponent<CreatureMoveScript>().creature;

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = creature.portrait;
    }
}
