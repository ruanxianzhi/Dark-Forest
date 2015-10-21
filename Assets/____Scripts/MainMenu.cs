using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void loadStart() {
		Application.LoadLevel ("StartGame");
	}
	public void loadHelp() {
		Application.LoadLevel ("Help");
	}
}
