using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnScreen : MonoBehaviour
{

    public GameObject uiObject;
    public float howLongTextStays;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(howLongTextStays);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
