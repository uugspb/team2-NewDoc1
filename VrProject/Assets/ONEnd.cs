using UnityEngine;
using System.Collections;

public class ONEnd : MonoBehaviour {

	public Light[] light;
	public float time;
	public float speed;
	private bool iscol=false;
	void OnColliderEnter2D(Collider col)
	{
		iscol = true;
	}

	void Update()
	{
		if (!iscol)
			return;
		if (time < 0f)
			Application.Quit ();

		time -= Time.deltaTime;
		for(int i=0; i<light.Length; ++i)
		light[i].range += speed*Time.deltaTime;
	}
}
