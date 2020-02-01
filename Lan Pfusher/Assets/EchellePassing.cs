using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class EchellePassing : MonoBehaviour
{

    //Destination dummy gameobject to be teleported on
    public GameObject DestinationToTp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //here the collider is normally the player
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(col.gameObject.name == "Player"){
            var dummyObjectDestPosition = DestinationToTp.gameObject.transform.position;
            col.gameObject.transform.position = dummyObjectDestPosition;
            var lastActiveCamera = Camera.current;
            //lastActiveCamera.transform.position = dummyObjectDestPosition;
          
        }
        

    }
}
