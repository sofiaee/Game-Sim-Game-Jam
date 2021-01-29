using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_GravityField : MonoBehaviour
{
    public float gravityFieldDirection;
    public RigidBody_CharController play1;
    // Start is called before the first frame update
 /*   private void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 */
    private void OnTriggerEnter2D(Collider2D coll)
    {
        play1 = coll.gameObject.GetComponent<RigidBody_CharController>();
        if (coll.CompareTag("Player"))
        {
//            Debug.Log(gravityFieldDirection);
            if (gravityFieldDirection != play1.gravityDirection)
            {
                play1.GravitySwitch(gravityFieldDirection);
//                Debug.Log("Switch!");
            }
        }
    }
}
