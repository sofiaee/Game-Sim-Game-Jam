using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTutorialLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider gameObjectInformation)
    {
        SceneManager.LoadScene("Tutorial_Level");
    }
}
