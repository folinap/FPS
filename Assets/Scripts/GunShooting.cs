using System.Collections;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField]private Transform _bulletSpawnPoint;
    [SerializeField]private GameObject _bulletPrefab;
    [SerializeField]private float _bulletSpeed = 10;
    private float _fireRate = 15;
    private float _lastfired;
    private int _shootingMode;


 

    void Update()
    {
        Shoot(ChooseShootingMode());            
    }


    private void SpawnBullet()
    {
        if (Time.time - _lastfired > 1 / _fireRate)
        {
            _lastfired = Time.time;
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = _bulletSpawnPoint.forward * _bulletSpeed;
        }
    }


    private void Shoot(int shootingMode)
    {
        switch (shootingMode)
        {
            case 0:
                if (Input.GetMouseButtonDown(0))
                {
                    SpawnBullet();
                }
                break;
            case 1:
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(ThreeBulletShooting());
                }
                break;
            case 2:
                if (Input.GetMouseButton(0))
                {
                    SpawnBullet();
                }
                break;
        }
    }

    private int ChooseShootingMode()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (_shootingMode != 2)
                _shootingMode++;
            else
                _shootingMode = 0;
        }
        return _shootingMode;
    }
    IEnumerator ThreeBulletShooting() 
    {    
        for(int i = 0; i < 3; i++)
        {
            SpawnBullet();
            yield return new WaitForSeconds(0.07f);
        }       
    }
}
