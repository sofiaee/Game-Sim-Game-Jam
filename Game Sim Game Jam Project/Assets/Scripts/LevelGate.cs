using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour
{
    public GameObject winScreen;

    private void Start()
    {
        winScreen.SetActive(false);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            winScreen.SetActive(true);
            StartCoroutine("WinLevel");
        }
       
    }

    public IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(.25f);
        Time.timeScale = 0;
    }
}
