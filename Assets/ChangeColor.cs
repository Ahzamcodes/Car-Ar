using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Material mat;

    public List<Color> color = new List<Color>(); 

    public void ChangeColorButton(int num)
    {
        mat.color = color[num];
    }
}
