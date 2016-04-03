using UnityEngine;
using System.Collections.Generic;

namespace ProjectVR {
	public class Player : MonoBehaviour {
		public static Player self;
		[SerializeField]
		private GameObject WallStreet;
		[SerializeField]
		private Transform SerTrans;

		[SerializeField]
		private Camera CameraObject;

		[SerializeField]
		private float BuildTime, DestroyingTime, MoveTime;

		[SerializeField]
		private Cloud MyCloud;

		[SerializeField]
		private float grabDistance;

		private List<Cloud> CloudsStreet = new List<Cloud>(0);

		private bool Building;
		private MeshFilter Drawned;

		private Cloud MovingTarget;

		public void Awake() {
			self = this;
		}

		void Update()
		{
			RaycastHit raycast;
			Physics.Raycast (CameraObject.ScreenPointToRay (new Vector2 (Screen.width / 2, Screen.height / 2)), out raycast, grabDistance);

			bool IsHere = false;

			for (int i=0; i<CloudsStreet.Count; ++i) {
				Cloud cl = CloudsStreet [i];
				if (!cl || cl.street.Destruction) {
					CloudsStreet.RemoveAt (i);
				}
			}
			for (int i=0; i<CloudsStreet.Count; ++i) {
				Cloud cl = CloudsStreet [i];
				if (raycast.collider && raycast.collider.tag == "Cloud" &&
					cl.IdCloud == raycast.collider.GetComponent<Cloud> ().IdCloud && MovingTarget == null) {
					if (cl.street.State == States.Nothing) {
						cl.street.State = States.Building;
					} else
						if (cl.street.State == States.Built) {
						MovingTarget = cl;					
					}
					IsHere = true;
				} else if (cl.street.State == States.Building) {
					cl.street.State = States.Nothing;
				}
					
				cl.street.start = MyCloud.EndVertex;
				cl.street.end = cl.EndVertex;
				cl.street.width = SerTrans.right*(-1)*cl.Width;
			}
			if (MovingTarget != null) {
				Animation (MovingTarget);
			} else if (!IsHere && raycast.collider && raycast.collider.tag == "Cloud") {
				Cloud d = raycast.collider.GetComponent<Cloud> ();
				if (d == MyCloud)
					return;
				if (d.street != null && !d.street.Destruction) {
					Debug.LogError ("Street Already Here!!!");
				}
				StreetComponent st = (Instantiate (WallStreet, Vector3.zero, Quaternion.identity)as GameObject)
					.GetComponent<StreetComponent> ();
				d.street = st;
				st.start = MyCloud.EndVertex;
				st.end = d.EndVertex;
				st.Halo = d.GetComponentInChildren<Light>();
				st.width = SerTrans.right*(-1)*d.Width;
				st.BuildingTime = BuildTime;
				st.CreateMesh ();
				CloudsStreet.Add (d);
			}	
		}

		private void Animation(Cloud cl)
		{
			Vector3 posA = cl.street.start;
			Vector3 posB = cl.street.end;

			transform.position = Vector3.Lerp (posA, posB, Mathf.Clamp01 ((cl.street.CurrentTime-1.5f - cl.street.BuildingTime) / MoveTime));

			if (cl.street.CurrentTime-1.5f > MoveTime + cl.street.BuildingTime) {
				MyCloud = cl;
				MovingTarget = null;
				transform.parent = cl.transform;
				transform.position = posB;
				cl.street.State = States.Nothing;
				cl.street.UpgradeLight();
			}
		}


		private bool GetStreet(int id)
		{
			foreach (Cloud cloud in CloudsStreet) {
				if (cloud.IdCloud==id) return true;
			}
			return false;
		}


	}
}
