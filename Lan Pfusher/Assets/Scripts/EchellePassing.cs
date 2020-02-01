using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class EchellePassing : MonoBehaviour
{

    //Destination dummy gameobject to be teleported on
    public GameObject DestinationToTp;
    //Reference to the camera to pass to it and allow player to see the good screen
    public Camera DestinationCamera;
    //When true Change the way player is currently facing when arriving on the TP destination
    public bool FlipFacingWhenArriveToTp;
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
            var lastActiveCamera = Camera.current.gameObject;
            
            //yield return new WaitForSeconds(3);
            Camera.current.gameObject.SetActive(false); //disable the previous scene camera
            DestinationCamera.gameObject.SetActive(true); //enable the current one

            //if(FlipFacingWhenArriveToTp)
                
        }
        
        
        

    }
}