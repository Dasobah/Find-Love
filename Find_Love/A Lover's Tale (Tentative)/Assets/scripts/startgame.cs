using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour {
    
    public GameObject canv;
    public GameObject hadd;
    public GameObject platform;
    public GameObject playersprite;
    public GameObject heart;
    public GameObject spikes;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
        {
            Destroy(canv);
            Destroy(hadd);
            Destroy(this);
            platform.SetActive(true);
            playersprite.SetActive(true);
            heart.SetActive(true);
            spikes.SetActive(true);
        }
	}
}
