using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBrianLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider gameObjectInformation)
    {
        SceneManager.LoadScene("Level_002_Gray_Area_Gravity");
    }
}
