using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public Button FireButton;



    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
