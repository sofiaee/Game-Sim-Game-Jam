using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    public bool lightAsset;

    private Collider2D myCollider;
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ToggleManager.Instance.isLight)
        {
            if(lightAsset)
            {
                //turn On collider, normal render
                myCollider.enabled = true;
                mySprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                //turn off collider, lower opacity
                myCollider.enabled = false;
                mySprite.color = new Color(1.0f, 1.0f, 1.0f, .3f);
            }

        }
        else
        {
            if(lightAsset)
            {
                //turn off collider, lower opacity
                myCollider.enabled = false;
                mySprite.color = new Color(1.0f, 1.0f, 1.0f, .3f);
            }
            else
            {
                //turn on collider, normal render
                myCollider.enabled = true;
                mySprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}
