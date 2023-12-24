using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTpManagerScript : MonoBehaviour
{
    [SerializeField] private Vector3 pos0;
    [SerializeField] private Vector3 pos1;
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;
    [SerializeField] private Vector3 pos3;
    [SerializeField] private Vector3 pos4;

    [SerializeField] private Camera mainCam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            mainCam.transform.position = pos0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCam.transform.position = pos1;
            map1.SetActive(true);
            map2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //mainCam.transform.position = pos1;
            map1.SetActive(false);
            map2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mainCam.transform.position = pos3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mainCam.transform.position = pos4;
        }
    }
}
