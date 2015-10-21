using UnityEngine;
using System.Collections;

public class Signal : MonoBehaviour {

	public float initSize;
	public float deltaSize;
	float updateSize;
	float size;
	float targetSize;
	public int maxTurns;
	int turn = 0;
	Color col;
	public GameObject signalPrefab;
	SpriteRenderer[] sprtrd = new SpriteRenderer[9];
	GameObject[] signals = new GameObject[9];
	Vector3[] vectors = {   new Vector3(-1f, 1f),   Vector3.up,     new Vector3(1f, 1f),
		Vector3.left,           Vector3.zero,   Vector3.right,
		new Vector3(-1f, -1f),  Vector3.down,   new Vector3(1f, -1f)    };
	
	public float mapSize;
	
	// Use this for initialization
	void Awake () {
		size = initSize;
		targetSize = size;
		mapSize = Controller.S.mapSize;
		
		for (int i = 0; i < 9; ++i) {
			signals[i] = Instantiate(signalPrefab) as GameObject;
			signals[i].transform.parent = transform;
			signals[i].transform.localPosition = vectors[i] * mapSize;
			sprtrd[i] = signals[i].GetComponent<SpriteRenderer>();
		}
		//Init(transform.position, Color.blue);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyUp(KeyCode.Space)) {
//			Propagate();
//		}
	}
	
	public void Init(Vector3 Pos, Color Col){
		col = Col;
		transform.position = Pos;
		for (int i = 0; i < 9; ++i) {
			signals[i].transform.localPosition = vectors[i] * mapSize;
			sprtrd[i].color = col;
		}
		Propagate ();
	}
	
	void FixedUpdate() {
		if (size < targetSize) {
			size += updateSize / 75f;
			col.a = 1f / (0.5f*size +1) * 0.95f + 0.05f;
			for (int i = 0; i < 9; ++i){
				signals[i].transform.localScale = new Vector3(size, size, 1f);
			}
		}
	}
	
	public void Propagate() {
		turn++;
		updateSize = (0.1f + 1f / turn)*deltaSize; 
		targetSize += updateSize;
		//col.a -= 1f / maxTurns;
		//print(col.a);
		for (int i = 0; i < 9; ++i) {
			sprtrd[i].color = col;
		}
		if (turn > maxTurns) Destroy(this.gameObject);
	}
}
