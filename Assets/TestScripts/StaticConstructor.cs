using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticConstructor : MonoBehaviour
{
    private void Start()
    {
        Employee e1 = new Employee();
        Employee e2 = new Employee();
        var e3 = new Employee();
        var e4 = new Employee();
    }
}

public class Employee
{
    public static string company;

    public int employeeID;
    public string firstName, lastName;
    public int salary;

    public Employee()
    {
        Debug.Log("Initialized Instance Members");
    }

    static Employee()
    {
        company = "QTArts";
        Debug.Log("Initiailized Static Memebers");
    }
}
