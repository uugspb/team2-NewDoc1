using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraStartet : MonoBehaviour {
	public Camera ThisCamera;

	public float time;
	public Image image;
	private float t;

	void Start()
	{
		t = 0;
	}
	void Update()
	{
		if (t >time)
			Destroy (this);
		t += Time.deltaTime;
		image.color = new Color (image.color.r, image.color.g, image.color.b, (t-1f) / time);
	}
}
