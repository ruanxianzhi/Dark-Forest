using UnityEngine;
using System.Collections;

public class AdjustPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RectTransform rt = transform.Find ("Button (Scan)").gameObject.GetComponent<RectTransform> ();
		rt.anchorMin=new Vector2(0.25f, 0.07f+0.8f*(Controller.S.finalSteps/Controller.S.initSteps));
		rt.anchorMax=new Vector2(0.9f, 0.13f+0.8f*(Controller.S.finalSteps/Controller.S.initSteps));
		GameObject go = transform.Find ("BarBackground").gameObject;
		rt = go.transform.Find ("GreenBar").gameObject.GetComponent<RectTransform> ();
		rt.anchorMin=new Vector2(0.1f, Controller.S.finalSteps/Controller.S.initSteps);
		rt.anchorMax=new Vector2(0.9f, 1f);
		rt = go.transform.Find ("YellowBar").gameObject.GetComponent<RectTransform> ();
		rt.anchorMin=new Vector2(0.1f, 0f);
		rt.anchorMax=new Vector2(0.9f, Controller.S.finalSteps/Controller.S.initSteps);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = transform.Find ("BarBackground").gameObject;
		RectTransform rt = go.transform.Find ("BlackBar").gameObject.GetComponent<RectTransform> ();
		if (Controller.S.steps<=0)
			rt.anchorMin=new Vector2(0.1f, 0);
		else
			rt.anchorMin=new Vector2(0.1f, Controller.S.steps/Controller.S.initSteps);
		rt.anchorMax=new Vector2(0.9f, 1f);
	}
}
