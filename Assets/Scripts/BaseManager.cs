﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
    public virtual void DoStart() {}
    public virtual void DoUpdate() {}
    public virtual void DoFixedUpdate() {}
}
