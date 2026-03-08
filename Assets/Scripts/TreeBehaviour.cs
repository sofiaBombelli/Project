using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public Transform TreeLive;
    public Transform TreeDeath;
    public FireBehaviour Fire;
    public float treeLife = 1f;
    public float treeLifeMin = 0.01f;
    public bool treeOnFire;
    public float timeLocal;
    public float timeCheckSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLocal = Time.time;
    }

    void SetTreeVisible()
    {
        if (treeLife >= treeLifeMin)
        {
            TreeLive.gameObject.SetActive(true);
            TreeDeath.gameObject.SetActive(false);
        }
        else
        {
            TreeLive.gameObject.SetActive(false);
            TreeDeath.gameObject.SetActive(true);
        }
    }

    void UpdateLife()
    {
        if (treeOnFire)
        {
            
            if (treeLife >= treeLifeMin)
            {
                Fire.StartFire();
                treeLife -= Fire.GetDammage();
            }
            else
            {
                treeOnFire = false;
                Fire.StopFire();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeLocal >= timeCheckSpeed)
        {
            timeLocal = Time.time;
            UpdateLife();
            SetTreeVisible();
        }
        else
        {

        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log("OnCollisionEnter: " + _collision);
    }

    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log("OnTriggerEnter: " + _other);
    }

}
