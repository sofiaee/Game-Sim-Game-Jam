using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLarryLevel : MonoBehaviour
{

    void OnTriggerEnter(Collider gameObjectInformation)
    {
        SceneManager.LoadScene("Larry's level pt2");
    }
}
