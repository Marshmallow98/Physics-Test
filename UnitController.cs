using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
   public float speed = 15f;
   public float hitCooldown = 20f;
   Rigidbody2D rb;
   
   private Transform target;
   private float cooldown;
   private float dir;
   private Quaternion qdir;
   private Vector2 lookdir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if (cooldown > 0)
        {
            cooldown--;
            return;
        }
        if ((rb.velocity).magnitude > (lookdir.normalized * speed).magnitude)
        {
            cooldown = hitCooldown;
            return;
        }
        if (MarkerController.OldMarker == null)
        {
            return;
        }
        lookdir = MarkerController.OldMarker.transform.position - transform.position;
        dir = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        qdir = Quaternion.AngleAxis(dir, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, qdir, 5f * Time.deltaTime);
        rb.velocity = (lookdir.normalized * speed);
    }
}
