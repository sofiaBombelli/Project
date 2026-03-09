using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public ParticleSystem FireVFX;
    public ParticleSystem SmokeVFX;
    public Transform FireFloor;

    public float fireLive = 0f;

    public float smokeTimeLive = 10f;
    public float smokeStartTime = 0f;

    public float fireDammage = 0.005f;
    public float fireSpeed = 0.005f;

    public bool isFireActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FireVFX.Stop();
        SmokeVFX.Stop();
        FireFloor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireActive)
        {
            fireLive += fireSpeed;
        }
        else
        {
            fireLive = 0f;
        }
        SetFireDiameter(fireLive);

        if (SmokeVFX.isPlaying)
        {
            if(Time.time - smokeStartTime > smokeTimeLive)
            {
                SmokeVFX.Stop();
            }
        }
    }

    public float floorFormFactor = 0.25f;

    private void SetFireDiameter(float _r)
    {
        this.GetComponent<SphereCollider>().radius = _r;
        //FireFloor.transform.localScale = _r;
        FireFloor.transform.localScale = new Vector3(_r * floorFormFactor, 0f, _r * floorFormFactor);
    }

    public void StartFire()
    {
        isFireActive = true;
        if (!FireVFX.isPlaying)
        {
            FireVFX.Play();
            FireFloor.gameObject.SetActive(true);
        }
    }

    public void StopFire()
    {
        if (isFireActive)
        {
            SmokeVFX.Play();
            smokeStartTime = Time.time;
        }
        isFireActive = false;
        FireVFX.Stop();
        FireFloor.gameObject.SetActive(false);
    }

    public float GetDammage()
    {
        return fireDammage;
    }

    private void OnTriggerEnter(Collider _other)
    {
        //Debug.Log("FIRE-OnTriggerEnter: " + _other);
        if (_other.gameObject.tag == "WatherTag")
        {
            fireLive -= _other.GetComponent<WatherBehaviour>().watherLive;
            if(fireLive <= 0f)
            {
                StopFire();
            }
        }
        if (_other.gameObject.tag == "FireTag")
        {
        }
        if (_other.gameObject.tag == "TreeTag")
        {
        }
    }

}
