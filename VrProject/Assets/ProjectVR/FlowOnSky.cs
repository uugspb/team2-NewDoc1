using UnityEngine;
using System.Collections;

namespace ProjectVR.Sky
{
	public class FlowOnSky : MonoBehaviour {

		private Transform ThisTransform;

		[SerializeField]
		private float Radius = 1f;
		[SerializeField]
		private float Speed = 1f;
		[SerializeField]
		private float Flow = 0.015f;

		private float sqrRadius = 1f;
		private Vector3 MoveVector;
		private Vector3 StartPosition;

		void Start()
		{
			sqrRadius = Radius * Radius;
			ThisTransform = transform;
			StartPosition = ThisTransform.position;
			MoveVector = GetRandomVector ();
		}

		void Update()
		{

			ThisTransform.Translate (MoveVector*Time.deltaTime*Speed);
			ChangeMoveVector ();
		}

		private Vector3 GetRandomVector()
		{
			return Random.insideUnitSphere;
				
		}

		private void ChangeMoveVector()
		{
			Vector3 rand;
			Vector3 len =  StartPosition - ThisTransform.position;
			if (len.sqrMagnitude >= sqrRadius * 0.8f) {
				MoveVector = (len + MoveVector * Flow).normalized;
			}
				else {
				MoveVector=(MoveVector+GetRandomVector()*Flow).normalized;
			}
		}

	}
}