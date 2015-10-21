using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TransferData : MonoBehaviour {
	public static int numPlayers;
	public static int mapSize;
	static bool created;
	public static int round;
	public static List<int> kill, death;
	// Use this for initialization
	void Start () {
		numPlayers = 4;
		mapSize = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake() {
		numPlayers = 2;
		mapSize = 1;
		if (created) {
			Destroy (transform.gameObject);
		} else {
			created = true;
		}
		round = 0;
		//kill.Clear ();
		//death.Clear ();
		kill = new List<int> ();
		death = new List<int> ();
		for (int i=0; i<4; ++i) {
			kill.Add (0);
			death.Add (0);
		}
		DontDestroyOnLoad (transform.gameObject);
	}
}
