using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;

    [SerializeField] Transform shootPoint = null;

    [SerializeField] float bulletSpeed = 1.0f;


    void ApplyForce(Rigidbody rigid)
    {
        Vector3 force = shootPoint.forward * bulletSpeed;
        rigid.AddForce(force);
    }

    public void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation, null);

        if (bullet.TryGetComponent(out Rigidbody rigid))
            ApplyForce(rigid);

       

    }

    public void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.layer == LayerMask.NameToLayer("Target"))
        {
            Destroy(bulletPrefab);
        }
    }
}
