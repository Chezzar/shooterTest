using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float AxisX, AxisY,MouseX,MouseY;
    private int Layer;
    private Score.CameraType CameraType;
    private Camera FPS;

    private float speed;

    public float Speed {

        get { return speed; }
        set { speed = value; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void Start() {

        Speed = 8f;
        Layer = LayerMask.GetMask("Floor");
        CameraType = Score.MyType;

        if (CameraType == Score.CameraType.FPS)
        {
            FPS = Camera.main.GetComponent<Camera>();
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        AxisX = InputManager.GetAxisHorizontal();
        AxisY = InputManager.GetAxisVertical();
        
        MouseX = InputManager.MouseX();
        MouseY = InputManager.MouseY();
    }

    void FixedUpdate()
    {

        Move();

        if (CameraType == Score.CameraType.TPS)
            TurnTPS();
        else if (CameraType == Score.CameraType.FPS)
            TurnFPS();

    }

    void TurnFPS() {

        this.transform.Rotate(new Vector3(0, MouseX, 0));

        //giro en eje Y
        //FPS.transform.Rotate(new Vector3(-MouseY, 0, 0));
    }

    void TurnTPS() {

        Ray CamToMousePos = Camera.main.ScreenPointToRay(InputManager.MousePosition());

        RaycastHit rayFloor;

        if (Physics.Raycast(CamToMousePos, out rayFloor, 100, Layer)) {

            Vector3 PlayerMouseDistance = rayFloor.point - transform.position;
            PlayerMouseDistance.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(PlayerMouseDistance);

            rb.MoveRotation(newRotation);
        }
    }

    void Move() {

        Vector3 mov_side,mov_forward = Vector3.zero;

        if (CameraType == Score.CameraType.TPS)
        {
           mov_side = Vector3.right * AxisX * speed * Time.deltaTime;
           mov_forward = Vector3.forward * AxisY * speed * Time.deltaTime;
        }

        else {

            mov_side = transform.right * AxisX * speed * Time.deltaTime;
            mov_forward = transform.forward * AxisY * speed * Time.deltaTime;
        }


        Vector3 total = mov_side + mov_forward;
        //rb.velocity = new Vector3(total.x,rb.velocity.y,total.z);
        rb.MovePosition(transform.position + total);
    }
}
