using UnityEngine;
using System.Collections;

public enum States {Nothing, Building, Built}
public class StreetComponent : MonoBehaviour {
	
	public Vector3 start { get; set; }
	public Vector3 end { get; set; }
	private Vector3 last; 
	public Vector3 width { get; set; }

	public float BuildingTime { get; set; }
	public float DestroyTime { get; set; }
	public float CurrentTime { get; set; }
	public States _crState = States.Nothing;
	public Light Halo;
	public bool Destruction{ get; private set; }

	public States State {
		get { return _crState; }
		set {
			if (value != _crState) {
				if (value == States.Building || value == States.Nothing) {
					last = mesh.vertices[1]+width;
				}

				if (value == States.Nothing) {
					CurrentTime = Mathf.Clamp(CurrentTime, 0, BuildingTime+1.5f);
				}
				_crState = value;
			}
		} 
	}

	public bool CreateFinish{ get; private set; }
	private Mesh mesh;

	void Awake() {
		Destruction = false;
	}

	void Start()
	{

		CurrentTime = 0f;
	}
	public void CreateMesh()
	{
		Halo.color = Color.white;
		Mesh d = new Mesh ();
		d.MarkDynamic ();
		d.vertices = new Vector3[] {  start-width,
			start-width,
			start+width,
			start+width};
		last = start;
		d.uv = new Vector2[] { new Vector2 (0, 0), new Vector2 (0, 1), new Vector2 (1, 1), new Vector2 (1, 0)};
		d.triangles = new int[] {0,1,3,1,2,3,3,1,0,3,2,1};

		gameObject.GetComponent<MeshFilter> ().mesh = mesh = d;
	}
	// Update is called once per frame
	void Update () {
	
		if (CurrentTime < -0.01f && _crState == States.Nothing) {
			Halo.color = Color.white;
			Destroy(gameObject);
			Destruction = true;
			return;
		}

//		if (time >= BuildingTime) {
//			//CreateFinish = true;
//			time = BuildingTime-0.1f;
//			return;
//		}

		if (State != States.Nothing)
			CurrentTime += Time.deltaTime;
		else
			CurrentTime -= Time.deltaTime;
		if (CurrentTime > BuildingTime+1.5f && State == States.Building)
			State = States.Built;
		UpdateMesh ();
	}


	private void UpdateMesh()
	{
		Vector3[] vertices = mesh.vertices;
		vertices [0] = start-width;


		if (State == States.Building) {
			if (CurrentTime<1.5f)
			{
				Vector3 col = Vector3.Lerp(new Vector3(1,1,1), new Vector3(1,1,0),CurrentTime/1.5f);
				Halo.color = new Color(col.x,col.y,col.z);
			} else
			{
				Vector3 col = Vector3.Lerp(new Vector3(1,1,0), new Vector3(1,0,0),
				                           (CurrentTime-1.5f) / BuildingTime);
				Halo.color = new Color(col.x,col.y,col.z);

				vertices [1] = Vector3.Lerp (start - width, end - width, 
				                             (CurrentTime-1.5f) / BuildingTime);
				vertices [2] = Vector3.Lerp (start + width, end + width, 
				                             (CurrentTime-1.5f) / BuildingTime);
			}
		} else if (State == States.Nothing) {
			Vector3 col = Vector3.Lerp(new Vector3(1,1,1), new Vector3(Halo.color.r,Halo.color.g,Halo.color.b),
			                           (CurrentTime-1.5f) / BuildingTime);
			Halo.color = new Color(col.x,col.y,col.z);
			vertices [1] = Vector3.Lerp (start - width, end - width, 
			                             (CurrentTime-1.5f) / BuildingTime);
			vertices [2] = Vector3.Lerp (start + width, end + width, 
			                             (CurrentTime-1.5f) / BuildingTime);
		} else{
			vertices [1] = end-width;
			vertices [2] = end+width;
		}


		vertices [3] = start+width;

		mesh.vertices = vertices;
		mesh.RecalculateBounds ();
		mesh.RecalculateNormals ();
	}

	public void UpgradeLight() {
		Halo.range = 20.0f;
		Portal.level++;
	}
}
