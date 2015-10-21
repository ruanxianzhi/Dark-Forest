using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody Rigid;
	public float speed;
	Quaternion bulletRotation;
	Vector3 originPos;


	// Use this for initialization
	void Start () {
		Rigid = GetComponent<Rigidbody>();
		bulletRotation = this.transform.rotation;
		originPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Rigid.velocity = bulletRotation * Vector3.up *-speed;
		if ((transform.position - originPos).magnitude > 10)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider coll){
		coll.transform.parent.GetComponent<Player>().takeDamage();
		Destroy (this.gameObject);
	}
}
