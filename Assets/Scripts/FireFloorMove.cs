using UnityEngine;

public class FireFloorMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float speedRotation = 45f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, speedRotation * Time.deltaTime, 0f, Space.Self);
        //this.transform.rotation = new Quaternion(0f, this.transform.rotation.y + speedRotation * Time., 0f, 0f);
    }
}
