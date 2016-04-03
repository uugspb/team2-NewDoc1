using UnityEngine;
using System.Collections;

namespace ProjectVR {
	public class Cloud : MonoBehaviour {

		[SerializeField]
		private Transform here;

		[SerializeField]
		private Transform end; 

		[SerializeField]
		private float width;

		public Vector3 EndVertex { get { return end.position; } }
		public float Width { get { return width; } }

		private int id = ++maxId;

		public static int maxId = 0;

		public Vector3 position { get { return here.position; } }

		public int IdCloud { get { return id; } }
		public StreetComponent street { get; set; }

		public void Update() {
			float l = (transform.position - Player.self.transform.position).magnitude;
			float r = Mathf.Sin (5f * Mathf.PI / 180) * l;
			if (GetComponent<SphereCollider>()) {
				GetComponent<SphereCollider>().radius = r;
			}
		}
	}
}