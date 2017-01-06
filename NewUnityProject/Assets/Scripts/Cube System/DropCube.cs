﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ThirdPersonCamera;

public class DropCube : MonoBehaviour {

	public GameObject prefabCube;
	public GameObject prefabCubeArcheo;
	GameObject cubeOnAss;

	ZoneGestion ZG;

	GameObject ScanningPanel; 

	OpenCloseBook OCB;

	public Transform LaunchCube;

	public bool isCubeOnGround;
	// Use this for initialization
	void Start () {
		ScanningPanel = GameObject.Find ("Scanning");
		ScanningPanel.SetActive (false);
		OCB = GameObject.Find ("ScriptManager").GetComponent<OpenCloseBook> ();
		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
		cubeOnAss = GameObject.Find ("ArtefactOnAss");
	}
	
	// Update is called once per frame
	void Update () {

		//drop it depending if we are in or out
		if(ZG.AmIInsideArea)
		{
			// et que j'appuie sur le bouton pour le cube, je le lache, mais ca instantiate le cube avec le module d'archéologie
			if (Input.GetButtonDown ("dropcube") && !isCubeOnGround) {
				Instantiate (prefabCubeArcheo,LaunchCube.position, LaunchCube.rotation);
				isCubeOnGround = true;
			}
		} else {
			if(Input.GetButtonDown("dropcube") && !isCubeOnGround /*&& OCB.isBookOpen == false*/){
				// et que j'appuie sur le bouton pour le cube, je le lache, mais ca instantiate le cube avec le module de recherche
				Instantiate (prefabCube,LaunchCube.position, LaunchCube.rotation);
				isCubeOnGround = true;
				ScanningPanel.SetActive (true);
				//StartCoroutine ("returnCubeBool");
			}
		}

		//pick it up
		if (isCubeOnGround) {
			cubeOnAss.SetActive (false);
		} else {
			cubeOnAss.SetActive (true);
		}

	}

	IEnumerator returnCubeBool () {
		yield return new WaitForSeconds (0.3f);
		ScanningPanel.SetActive (false);
		isCubeOnGround = false;
	}
}
