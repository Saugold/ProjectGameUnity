using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataInstance;
    public bool tutoToDo1 = true;
    public bool tutoToDo2 = true;
    public bool tutoToDo3 = true;
    public bool tutoToDo4 = true;
    public bool tutoToDo5 = true;
    public bool tutoToDo6 = true;

    private void Awake()
    {
        
        if (dataInstance == null)
        {
            dataInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
