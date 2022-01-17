using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingCylinder : MonoBehaviour
{
    private bool _filled;
    private float _value;

    public void IncrementyCylinderVolume(float value)
    {
        _value += value;

        if (_value >1) // silindirin boyutun tam olarak 1 yap // 1den ne kadar büyükse o kadar büyük silindir yarat
        {
            float leftValue = _value - 1;
            int cylinderCount = PlayerController.Current.cylinders.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (cylinderCount-1) - 0.25f, transform.localPosition.z);
            transform.localScale= new Vector3(0.5f, transform.localScale.y, 0.5f);
            PlayerController.Current.CreateCylinder(leftValue);
        }
        else if (_value < 0) //karaktere bu silindiri yok etmesini söyleyecegiz
        {
            PlayerController.Current.DestroyCylinder(this);
        }
        else // silindirin boyu guncellenecek
        {
            int cylinderCount = PlayerController.Current.cylinders.Count;
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f * (cylinderCount - 1) - 0.25f * _value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * _value, transform.localScale.y , 0.5f * _value);
        }
    }

   
}
