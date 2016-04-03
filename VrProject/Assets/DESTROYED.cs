using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DESTROYED : MonoBehaviour {

	public float time;
	public DESTROYED next;
	public bool IsStart;
	private float f;
	public Text txt;

	void Start()
	{
		f = time;
		txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, 0);
	}

	void Update()
	{
		if (!IsStart)
			return;
		if (f > 0f && f <= time / 2f) {
			txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, (f * 2f) / time);
			f -= Time.deltaTime;
			return;
		} else if (f >= time / 2f) {
			txt.color = new Color(txt.color.r,txt.color.g,txt.color.b, 1-(f)/(time));
			f -= Time.deltaTime;
		} else
		if (f <= 0f) {
			if (next==null)
			{
				Application.LoadLevel(1);
			} else
			{
			IsStart=false;
			next.IsStart=true;
			}
			return;
		}



	}


}
