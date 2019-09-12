using UnityEngine;
public class CameraController : MonoBehaviour {
    public float speed = 2.0f;
    public Transform target;
    void Start () {}
    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveLengthWise = Input.GetAxis("Vertical");
        float moveVertical = 0;
        if(Input.GetKey("space")) moveVertical = 1;
        if(Input.GetKey("left shift")) moveVertical = -1;
        transform.Translate(new Vector3(moveHorizontal, moveVertical, moveLengthWise) * speed);
        transform.LookAt(target.position);
    }
}
