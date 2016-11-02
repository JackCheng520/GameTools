using UnityEngine;
using System.Collections;

public class JLogHelpBase<T> : JSington<T> where T : class,new()
{
    public bool beInit { set; get; }
    public void Init()
    {
        OnInit();
        beInit = true;
    }

    public void Unit()
    {
        OnUnit();
        beInit = false;
    }

    public virtual void OnInit() { }
    public virtual void OnUnit() { }


}
