using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectscript : MonoBehaviour
{
    
     void OnCollisionEnter(Collision gameObjectInformation)
    {
        SceneManager.LoadScene("Test_Gravity");
    }
}
