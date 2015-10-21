using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class GameScene : MonoBehaviour {
	public GameObject signalPrefab;
	// Use this for initialization
	void Start () {
		int np = Controller.S.numPlayers;
		for (int i=np; i<4; ++i) {
			GameObject.Find ("Player" + (i + 1).ToString ()).SetActive (false);
			GameObject.Find ("SideCamera" + i.ToString ()).SetActive (false);
			transform.Find ("TextP" + (i + 1).ToString ()).gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Button bs = transform.Find ("Panel").gameObject.transform.Find ("Button (Scan)").GetComponent<Button> ();
		if (!Controller.S.scanned)
			bs.interactable = true;
		else
			bs.interactable = false;
		Button be = transform.Find ("Panel").gameObject.transform.Find ("Button (End Turn)").GetComponent<Button> ();
		if (Controller.S.scanned)
			be.interactable = true;
		else
			be.interactable = false;
	}
	public void scan() {
		Controller.S.playerList [Controller.S.currentPlayer - 1].GetComponent<Player>().Stop ();
		float ratio = Controller.S.steps / Controller.S.initSteps;
		Controller.S.steps = Controller.S.finalSteps;
		Controller.S.scanned = true;
		float sight = ratio * (Controller.S.cameraMaxSight - Controller.S.cameraMinSight) + Controller.S.cameraMinSight;
		Controller.S.cameraList [0].transform.Find("Frame").transform.localScale = new Vector3 (sight,sight,1);
		int cp = Controller.S.currentPlayer;
		/*GameObject cpObj = GameObject.Find ("Player" + cp.ToString ());
		Vector3 pos = cpObj.transform.position;
		Color col = cpObj.GetComponent<SpriteRenderer> ().color;*/
		Player p = Controller.S.playerList [cp - 1];
		Vector3 pos = p.transform.position;
		Color col=p.members[0].GetComponent<SpriteRenderer> ().color;
		GameObject sigObj=Instantiate(signalPrefab) as GameObject;
		Signal sig = sigObj.GetComponent<Signal> ();
		sig.Init(pos,col);
		List<Signal> sl;
		switch (cp) {
		case 1:
			sl=Controller.S.signalList1;
			break;
		case 2:
			sl=Controller.S.signalList2;
			break;
		case 3:
			sl=Controller.S.signalList3;
			break;
		case 4:
			sl=Controller.S.signalList4;
			break;
		default:
			print ("Error!");
			return;
		}
		sl.Add (sig);
	}
	public void endTurn() {
		Controller.S.playerList [Controller.S.currentPlayer - 1].GetComponent<Player>().Stop ();
		Controller.S.shot = true;
		float sight = Controller.S.cameraMinSight;
		Controller.S.cameraList [0].transform.Find("Frame").transform.localScale
			= new Vector3 (sight,sight,1);
		Controller.S.steps = Controller.S.initSteps;
		int np = Controller.S.numPlayers;
		int cp = Controller.S.currentPlayer;
		List<Signal> sl;
		switch (cp) {
		case 1:
			sl=Controller.S.signalList1;
			break;
		case 2:
			sl=Controller.S.signalList2;
			break;
		case 3:
			sl=Controller.S.signalList3;
			break;
		case 4:
			sl=Controller.S.signalList4;
			break;
		default:
			print ("Error!");
			return;
		}
		for (int i=0; i<sl.Count; ++i) {
			if (sl [i])
				sl [i].Propagate ();
			else
				sl.RemoveAt (i);
		}
		do {
			cp = cp % np + 1;
		} while (!Controller.S.playerIsAlive[cp-1]);
		Controller.S.currentPlayer = cp;
		Controller.S.scanned = false;
		for (int i=0; i<np; ++i) {
			int value = (cp + i + np - 1) % np + 1;
			Controller.S.cameraList [i].target = GameObject.Find ("Player" + value.ToString ()).transform;
			transform.Find ("TextP" + (i + 1).ToString ()).GetComponent<Text> ().text = "Player " + value.ToString ();
		}
	}
}
