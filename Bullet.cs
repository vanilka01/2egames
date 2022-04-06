using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;

    public LayerMask whatIsSolid;

    public static Vector3 spawn;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy") || hitInfo.collider.CompareTag("Boss"))
            {
                EnemyDefolt.isAttacked = true;
                hitInfo.collider.GetComponent<EnemyDefolt>().Dead(Gun.damage);
                spawn = gameObject.transform.position;
                Gun.isSpawnDamage = true;
                Destroy(gameObject);
            }
        }
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
