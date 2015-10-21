using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void load2Players() {
		TransferData.numPlayers = 2;
		Application.LoadLevel ("StartGame2");
	}
	public void load3Players() {
		TransferData.numPlayers = 3;
		Application.LoadLevel ("StartGame2");
	}
	public void load4Players() {
		TransferData.numPlayers = 4;
		Application.LoadLevel ("StartGame2");
	}
	public void loadBack() {
		Application.LoadLevel ("MainMenu");
	}
}
