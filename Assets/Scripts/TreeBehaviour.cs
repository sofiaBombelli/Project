using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public Transform TreeLive;
    public Transform TreeDeath;
    public FireBehaviour Fire;
    public float treeLife = 1f;
    public float treeLifeMin = 0.01f;
    public float timeLocal;
    public float timeCheckSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLocal = Time.time;
        StartFireTree();
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
        if (Fire.isFireActive)
        {
            if (treeLife >= treeLifeMin)
            {
                Fire.StartFire();
                treeLife -= Fire.GetDammage();
            }
            else
            {
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

    public bool needToStartFire;
    public void StartFireTree()
    {
        if (needToStartFire)
        {
            StartFire();
            needToStartFire = false;
        }
    }

    public void StartFire()
    {
        Fire.gameObject.SetActive(true);
        Fire.StartFire();
    }

    private void OnTriggerEnter(Collider _other)
    {
        //Debug.Log("TREE-OnTriggerEnter: " + _other);
        if (_other.gameObject.tag == "WatherTag")
        {

        }
        if (_other.gameObject.tag == "FireTag")
        {
            Fire.StartFire();
        }
        if (_other.gameObject.tag == "TreeTag")
        {

        }
    }

}
