using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Start is called before the first frame update
	
	private Rigidbody playerRigidbody;
	public Vector3 defaultPosition;
	public Vector3 defaultRotation;
	
	private Vector3 pos;
	
	public float moveSpeedMagnification;
	//public float rotateSpeedMagnification;
	public float radius;
	
	private float speed;
	//private float rotate;

	//
	float moveHorizontal;
	float moveVertical;

	float inputMove;
	float inputRotate;
	//
	float dif;//not be used

	public void Start() {
		playerRigidbody = this.GetComponent<Rigidbody>();
		this.transform.position = defaultPosition;
		this.transform.Rotate(defaultRotation);
		this.transform.rotation = Quaternion.Euler(0, 45, 0);
	}
	
	// Update is called once per frame
	public void Update() {
		if (radius <= 0) radius = 50;
	}
	
	public void FixedUpdate() {
		
	moveHorizontal = Input.GetAxis("Horizontal");
	moveVertical = Input.GetAxis("Vertical");
	
	inputMove = Input.GetAxis("Vertical");
	inputRotate = Input.GetAxis("Horizontal");
	
	/*
	//this.transform.rotation = new Quaternion(0, this.transform.rotation.y+rotateSpeed*rotate, 0, 0);
	this.transform.Rotate(new Vector3(0, rotate, 0) * rotateSpeed);
	
	//playerRigidbody.AddForce(new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed);
	playerRigidbody.AddForce(moveSpeed * move * Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y), 0f, moveSpeed * move * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y));
	
	if (rotate!=0) {
	playerRigidbody.AddForce(moveSpeed * Mathf.Cos(Mathf.Deg2Rad * (this.transform.eulerAngles.y+45)), 0f, moveSpeed * -Mathf.Sin(Mathf.Deg2Rad * (this.transform.eulerAngles.y + 45)));
	}
	/*/
	
	//speed += inputMove;
	
	playerRigidbody.AddForce(inputMove * Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y), 0, inputMove * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y));
	
	//playerRigidbody.velocity = new Vector3(speed*Mathf.Cos(Mathf.Deg2Rad*this.transform.rotation.y),0,speed*Mathf.Sin(Mathf.Deg2Rad*this.transform.rotation.y));
	if (inputRotate != 0) {
		playerRigidbody.AddForce(inputRotate * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius, 0, inputRotate * -Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius);
	}
	/*
	if (inputRotate < 0) {
		playerRigidbody.AddForce(inputRotate * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius, 0, inputRotate * -Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius);
	}
	//*/
	
	//playerRigidbody.AddForce(inputRotate * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y), 0, inputRotate * -Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y));
	
	//*
	if ((this.transform.position - pos).magnitude > 0.001f) {
		transform.rotation = Quaternion.LookRotation(this.transform.position - pos);
	}
	//*/
	pos = this.transform.position;

	Debug.Log(playerRigidbody.velocity.magnitude,playerRigidbody);
	//*/
	}
}