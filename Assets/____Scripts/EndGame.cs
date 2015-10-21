using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void loadPlayAgain() {
		++TransferData.round;
		Application.LoadLevel ("GameScene");
	}
	public void loadMenu() {
		TransferData.round = 0;
		TransferData.kill = new List<int> ();
		TransferData.death = new List<int> ();
		for (int i=0; i<4; ++i) {
			TransferData.kill.Add (0);
			TransferData.death.Add (0);
		}
		Application.LoadLevel ("MainMenu");
	}
}
