using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int numPlayers = TransferData.numPlayers;
		GameObject go = transform.Find ("Bar").gameObject;
		go.transform.Find ("Round").GetComponent<Text> ().text = "Round " + TransferData.round.ToString ();
		go = transform.Find ("Leaderboard").gameObject;
		for (int i=0; i<numPlayers; ++i) {
			Text t;
			t = go.transform.Find ("Player" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = "Player " + (i + 1).ToString ();
			t = go.transform.Find ("Kill" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = TransferData.kill [i].ToString ();
			t = go.transform.Find ("Death" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = TransferData.death [i].ToString ();
		}
		for (int i=numPlayers; i<4; ++i) {
			Text t;
			t = go.transform.Find ("Player" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = "";
			t = go.transform.Find ("Kill" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = "";
			t = go.transform.Find ("Death" + (i + 1).ToString ()).GetComponent<Text> ();
			t.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
