using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform Target;
    public float Smooth;
    private Vector3 offset;
    private Score.CameraType SelectedType;

    void Awake() {

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SelectedType = Score.MyType;
    }

    void Start()
    {
        Smooth = 1;
        offset = transform.position - Target.position;

        if (SelectedType == Score.CameraType.FPS) {

            GetComponent<Camera>().fieldOfView = 60;
            transform.SetParent(Target.transform);
            transform.rotation = Quaternion.identity;
            transform.localPosition = Vector3.zero + new Vector3(-0.2f,0.25f,0.37f);

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (SelectedType == Score.CameraType.TPS)
        {
            Vector3 MyNewPosition = Target.position + offset;
            transform.position = Vector3.Lerp(transform.position, MyNewPosition, 1);
        }

    }
}
