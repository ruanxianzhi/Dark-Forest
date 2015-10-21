using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Infoo : MonoBehaviour {

	public static Infoo S;
	int count = 1;

	public void Awake(){
		S = this;
	}

	public void Update(){
		count += 1;
		if (count > 100)
			Destroy (this.gameObject);
	}

	public void Show(int p1, int p2){
		GameObject go = transform.Find ("TextP2").gameObject;
		go.GetComponent<Text> ().text = "Player " + p1.ToString () + " is killed by Player " + p2.ToString ();
	}

}
