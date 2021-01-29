using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    private SpriteRenderer mySprite;
    public bool lightAsset;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ToggleManager.Instance.isLight)
        {
            if (lightAsset)
            {
                mySprite.color = new Color(.8f, .8f, .8f);
            }
            else
            {
                mySprite.color = new Color(.2f, .2f, .2f);
            }

        }
        else
        {
            if (lightAsset)
            {
                mySprite.color = new Color(.2f, .2f, .2f);
            }
            else
            {
                mySprite.color = new Color(.8f, .8f, .8f);
            }
        }
    }
}
