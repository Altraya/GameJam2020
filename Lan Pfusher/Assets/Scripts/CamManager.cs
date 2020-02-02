using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Camera[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        //Turn all cameras off, except the first default one
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        cameras[1].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
