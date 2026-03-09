using UnityEngine;

public class WatherBehaviour : MonoBehaviour
{
    public float watherLive = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _other)
    {
        //Debug.Log("FIRE-OnTriggerEnter: " + _other);
        if (_other.gameObject.tag == "WatherTag")
        {
        }
        if (_other.gameObject.tag == "FireTag")
        {
            GameObject.Destroy(this.gameObject);
            //this.gameObject.de
            //this.destroy(?)
            //gameObject.SetActive(false);
        }
        if (_other.gameObject.tag == "TreeTag")
        {
        }
    }
}
