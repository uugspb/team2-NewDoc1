using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public static int level = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Light> ().intensity = level / 3;
	}
}
