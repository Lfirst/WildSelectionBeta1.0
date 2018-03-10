using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {
	public string Scene;
	// Use this for initialization
	void Start () {
		Application.LoadLevel (Scene);
	}
}
