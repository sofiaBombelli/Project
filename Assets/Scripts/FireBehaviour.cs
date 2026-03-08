using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public ParticleSystem FireVFX;

    public float fireLive = 0f;

    public float fireDammage = 0.01f;
    public float fireSpeed = 0.001f;

    public bool isFireActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FireVFX.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFireActive)
        {
            fireLive += fireSpeed;
            this.GetComponent<SphereCollider>().radius = fireLive;
        }
    }

    public void StartFire()
    {
        isFireActive = true;
        if (!FireVFX.isPlaying)
        {
            FireVFX.Play();
        }
    }

    public void StopFire()
    {
        isFireActive = false;
        FireVFX.Stop();
    }

    public float GetDammage()
    {
        return fireDammage;
    }
}
