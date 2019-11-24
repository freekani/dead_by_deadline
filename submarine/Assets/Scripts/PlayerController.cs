using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody playerRigidbody;
    public Vector3 defaultPosition;
    public Vector3 defaultRotation;

    public float moveSpeed;
    public float rotateSpeed;
    private Vector3 pos;

    public float radius;

    float moveHorizontal;
    float moveVertical;

    float inputMove;
    float inputRotate;

    public void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        this.transform.position = defaultPosition;
        this.transform.Rotate(defaultRotation);
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
    }

    // Update is called once per frame
    public void Update()
    {
        if (radius <= 0) radius = 50;
        this.transform.rotation = new Quaternion(0,this.transform.rotation.y,0,this.transform.rotation.w);
    }

    public void FixedUpdate()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        inputMove = Input.GetAxis("Vertical");
        inputRotate = Input.GetAxis("Horizontal");


        playerRigidbody.AddForce(this.inputMove * this.transform.forward * this.moveSpeed);


        if (inputRotate != 0)
        {
            //playerRigidbody.AddForce(inputRotate * Mathf.Cos(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius, 0, inputRotate * -Mathf.Sin(Mathf.Deg2Rad * this.transform.eulerAngles.y) * Mathf.Pow(playerRigidbody.velocity.magnitude, 2) / radius);
            playerRigidbody.AddForce(this.inputRotate * this.transform.right * this.rotateSpeed);
        }

        if ((this.transform.position - this.pos).magnitude > 0.001f)
        {
            this.transform.rotation = Quaternion.LookRotation(this.transform.position - this.pos);
        }

        this.pos = this.transform.position;

        Debug.Log(playerRigidbody.velocity.magnitude, playerRigidbody);

    }
}