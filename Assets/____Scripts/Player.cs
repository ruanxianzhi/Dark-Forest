using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int playerNum;
	Rigidbody Rigid;
	public float Speed;
	public float rotationSpeed;
	Quaternion rotation;
	public Quaternion bulletRotation;
	public GameObject PlayerPrefab;
	public GameObject BulletPrefab;
	public GameObject InfooPrefab;
	//public Sprite tomb;
	public GameObject[] members = new GameObject[9];
	Vector3[] vectors = {   new Vector3(-1f, 1f),   Vector3.up,     new Vector3(1f, 1f),
		Vector3.left,           Vector3.zero,   Vector3.right,
		new Vector3(-1f, -1f),  Vector3.down,   new Vector3(1f, -1f)    };

	public Vector3 pos{
		get{return transform.position;}
		set{transform.position = value;}
	}
	Vector3 lastPos;

	// Use this for initialization
	void Start () {
		float x = Controller.S.permute[playerNum-1].x+Random.Range (0, Controller.S.mapSize /4);
		float y = Controller.S.permute[playerNum-1].y-Random.Range (0, Controller.S.mapSize /4);
		Vector3 tempPos = pos;
		tempPos.x = x;
		tempPos.y = y;
		pos = tempPos;
		rotation = transform.rotation;
		Rigid = GetComponent<Rigidbody>();
		lastPos = this.transform.position;
		//player.main
		for (int i = 0; i < 9; ++i)
		{
			members[i] = Instantiate(PlayerPrefab) as GameObject;
			members[i].transform.parent = transform;
			members[i].transform.localPosition = vectors[i]*Controller.S.mapSize;
		}
	}
	
	void Rotate(float angle) {
		rotation.eulerAngles += new Vector3(0f, 0f, 1f)*angle;
		for (int i = 0; i<9; ++i) {
			members[i].transform.rotation = rotation;
		}
	}
	
	void Move(){
		Vector3 speed = rotation * Vector3.up * -Speed;
		for (int i = 0; i<9; ++i) {
			members[i].GetComponent<Animator> ().SetFloat ("speed", Speed);
		}
		Rigid.velocity = speed;
		if (pos.x > Controller.S.mapSize / 2) {
			Vector3 nextPos = pos;
			nextPos.x = -Controller.S.mapSize+nextPos.x;
			pos = nextPos;
			//Controller.S.steps += Controller.S.mapSize;
		}
		if (pos.y > Controller.S.mapSize / 2) {
			Vector3 nextPos = pos;
			nextPos.y = -Controller.S.mapSize+nextPos.y;
			pos = nextPos;
			//Controller.S.steps += Controller.S.mapSize;
		}
		if (pos.x < -Controller.S.mapSize / 2) {
			Vector3 nextPos = pos;
			nextPos.x = Controller.S.mapSize+nextPos.x;
			pos = nextPos;
			//Controller.S.steps += Controller.S.mapSize;
		}
		if (pos.y < -Controller.S.mapSize / 2) {
			Vector3 nextPos = pos;
			nextPos.y = Controller.S.mapSize+nextPos.y;
			pos = nextPos;
			//Controller.S.steps += Controller.S.mapSize;
		}
	}
	
	public void Stop(){
		Rigid.velocity = Vector3.zero;
		for (int i = 0; i<9; ++i) {
			members[i].GetComponent<Animator> ().SetFloat ("speed", 0);
		}
	}
	
	void TurnAround() {
		Rotate(180f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = this.transform.position;
		float dist = (currentPos - lastPos).magnitude;
		if (dist > Controller.S.mapSize / 2)
			dist -= Controller.S.mapSize;
		Controller.S.steps -= dist;
		lastPos = currentPos;
		if (Controller.S.currentPlayer!=playerNum){
			return;
		}
		if (Input.GetKey(KeyCode.W)){
			if (Controller.S.scanned==false&&Controller.S.steps<=Controller.S.finalSteps){
				Stop();
				return;
			}
			if (Controller.S.steps<=0){
				Stop ();
				return;
			}
			Move();
		}
		else { Stop(); }
		if (Input.GetKeyDown(KeyCode.S))
		{
			TurnAround();
		}
		if (Input.GetKeyDown(KeyCode.Space)&&Controller.S.shot)
		{
			Controller.S.shot = false;
			GameObject bullet = Instantiate(BulletPrefab) as GameObject;
			bulletRotation = rotation;
			bulletRotation.eulerAngles += new Vector3(0f, 0f, 15f);
			bullet.transform.position = this.transform.position
				+(rotation) * Vector3.up * -Speed/1.5f;
			bullet.transform.rotation = rotation;
		}
	}
	
	void FixedUpdate()
	{
		if (Controller.S.currentPlayer!=playerNum){
			return;
		}
		if (Input.GetKey(KeyCode.A))
		{
			Rotate(rotationSpeed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			Rotate(-rotationSpeed);
		}
	}

	public void takeDamage(){
		if (Controller.S.playerIsAlive[playerNum-1])
		{
			print ("Player " + playerNum + " is killed by Player " + Controller.S.currentPlayer);
			GameObject infoo = Instantiate (InfooPrefab);
			infoo.GetComponent<Infoo>().Show(playerNum, Controller.S.currentPlayer);


			++TransferData.kill [Controller.S.currentPlayer - 1];
			++TransferData.death [playerNum - 1];
			for (int i=0; i<9; i++) {
				members [i].transform.rotation = Quaternion.Euler (0, 0, 0);
				members [i].transform.position += new Vector3 (0f, 0f, 1f);
				members [i].GetComponent<Animator> ().SetTrigger ("dead");
			}
			Controller.S.playerIsAlive [playerNum - 1] = false;
			Controller.S.NumofAlive--;
			if (Controller.S.NumofAlive == 1) {
				Application.LoadLevel ("EndGame");
			}
		}
	}
}
