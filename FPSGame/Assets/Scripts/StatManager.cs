﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public float PlayerMoveSpeed;
    public float AimSpeed;
    public float GravitySpeed;
    public float JumpSpeed;
    public bool CanGunShoot = true;
    public float BulletSpeed;

    public static StatManager instance;

    void Awake()
    {
        instance = this;
    }
}
