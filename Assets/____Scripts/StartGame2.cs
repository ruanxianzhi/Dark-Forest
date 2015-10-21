using UnityEngine;
using System.Collections;

public class StartGame2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void loadSmallMap() {
		TransferData.mapSize = 100;
		++TransferData.round;
		Application.LoadLevel ("GameScene");
	}
	public void loadMediumMap() {
		TransferData.mapSize = 150;
		++TransferData.round;
		Application.LoadLevel ("GameScene");
	}
	public void loadLargeMap() {
		TransferData.mapSize = 200;
		++TransferData.round;
		Application.LoadLevel ("GameScene");
	}
	public void loadBack() {
		Application.LoadLevel ("StartGame");
	}
}
