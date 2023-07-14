using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class UpdateSpriteScript : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Dropdown dropdown;

    private void OnEnable()
    {
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        image.sprite = dropdown.options[dropdown.value].image;
    }
}
