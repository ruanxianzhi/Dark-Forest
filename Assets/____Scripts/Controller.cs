using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Controller : MonoBehaviour {
	public static Controller S;
	public float steps;
	public float initSteps = 45;
	public float finalSteps = 15;
	public float cameraMaxSight = 15;
	public float cameraMinSight = 5;
	public int numPlayers;
	public int mapSize;
	public bool shot;
	public int currentPlayer;
	public bool scanned;
	public List<FollowCamera> cameraList;
	public List<Player> playerList;
	public List<Signal> signalList1, signalList2, signalList3, signalList4;
	public List<bool> playerIsAlive;
	public int NumofAlive;
	public Vector2 [] permute= new Vector2[4];
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake() {
		S = this;
		numPlayers = TransferData.numPlayers;
		mapSize = TransferData.mapSize;
		shot = true;
		steps = initSteps;
		currentPlayer = 1;
		NumofAlive = numPlayers;
		GameObject ground = GameObject.Find ("Ground");
		ground.transform.localScale = new Vector3 (mapSize * 3, mapSize * 3, 1);
		scanned = false;
		permute [0] = new Vector2(-mapSize/8*3, mapSize/8*3);
		permute [1] = new Vector2(mapSize/8, mapSize/8*3);
		permute [2] = new Vector2(-mapSize/8*3, -mapSize/8*1);
		permute [3] = new Vector2(mapSize/8, -mapSize/8);
		for (int i=0; i<10; i++) {
			int exa = Random.Range(0,1000)%4;
			int exb = Random.Range(0,1000)%4;
			Vector2 temp = permute[exa];
			permute[exa] = permute[exb];
			permute[exb] = temp;
		}
	}
}
