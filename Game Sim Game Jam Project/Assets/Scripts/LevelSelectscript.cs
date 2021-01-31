using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectscript : MonoBehaviour
{
    
     void OnTriggerEnter(Collider gameObjectInformation)
    {
        SceneManager.LoadScene("Test_Gravity");
    }
}
