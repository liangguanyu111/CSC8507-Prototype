using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireTime;
    public float bulletSpeed;
    public Transform fireTrans;
    public GameObject fireBullet;

    public float minRadius;
    public float maxRadius;
    public float strength;
    public float hardness;

    float timer = 0;
    public void Fire()
    {
        if (timer <= 0)
        {
            GameObject bullet = Instantiate(fireBullet, fireTrans.position, Quaternion.Euler(fireTrans.eulerAngles));
            bullet.GetComponent<Bullet>().SetBullet(bulletSpeed, fireTrans.forward ,minRadius,maxRadius,strength,hardness);
           timer = fireTime;
        }
        else
        {
            timer -= Time.deltaTime * 50;
        }
    }
}
