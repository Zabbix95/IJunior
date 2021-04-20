using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoss : MonoBehaviour
{
    // Start is called before the first frame update         
    [SerializeField] private int Count;
    [SerializeField] private int Radius;

    private void Start() {
        GameObject _boss = GameObject.Find("theBoss");        
        float angleStep = 360 / Count;
        for (int i = 0; i < Count; i++) 
        {
            GameObject newObject = Instantiate(_boss, new Vector3(Radius * Mathf.Sin(angleStep * i * Mathf.Deg2Rad), 0, Radius * Mathf.Cos(angleStep * i * Mathf.Deg2Rad)), Quaternion.identity);            
        }        
    }
}
