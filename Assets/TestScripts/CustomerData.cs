using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomerData
{
    public string firstName, lastName;
    public int age;
    public enum Gender { male, female, other }
    public Gender gender;
    public string occupation;

    public CustomerData(string firstName, string lastName, int age, CustomerData.Gender gender, string occupation)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.gender = gender;
        this.occupation = occupation;
    }
}
