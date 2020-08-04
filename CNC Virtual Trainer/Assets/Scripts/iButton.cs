using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class iButton : MonoBehaviour
{
    protected bool useable;
    protected bool animatable;

    protected virtual void Awake()
    {
        animatable = true;
        useable = true;
    }

    public abstract void OnButtonDown();
    public virtual void SetButtonAsUseable()
    {
        useable = true;
    }
    public virtual void SetButtonAsUnusable()
    {
        useable = false;
    }
    public virtual void SetButtonAnimatable(bool anim)
    {
        animatable = anim;
    }
    public bool GetButtonIsAnimatable()
    {
        return animatable;
    }
}
