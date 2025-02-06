using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 1f;
    [SerializeField] private AudioSource fire;
    [SerializeField] private GameObject flash;

    private float _gameTime;

    private void Update()
    {
        _gameTime += Time.deltaTime;

        if (Input.GetMouseButton(0) && _gameTime > 0.15f)
        {
            Schoot();
            _gameTime = 0;
        }
    }

    private void Schoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletForce;
        fire.pitch = Random.Range(0.8f, 1.2f);
        fire.Play();
        flash.SetActive(true);
        Invoke("HideFlash", 0.1f);
    }
    
    private void HideFlash()
    {
        flash.SetActive(false);
    }
}