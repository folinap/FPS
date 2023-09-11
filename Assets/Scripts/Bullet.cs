using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float _life = 3;

    void Awake()
    {
        Destroy(gameObject, _life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}