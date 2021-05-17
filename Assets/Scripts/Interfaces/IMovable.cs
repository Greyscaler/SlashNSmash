using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Imovable
{
    Vector3 Speed { get; set; }
    Vector3 MaxSpeed { get;  }
    void SetTranslate(Vector3 direction);
    void SetRotate(Vector3 direction);
}