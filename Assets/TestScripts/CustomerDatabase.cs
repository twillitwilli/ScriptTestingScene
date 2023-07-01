using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDatabase : MonoBehaviour
{
    [SerializeField] private CustomerData[] _customerData;

    private CustomerData _johnSmith;
    private CustomerData _janeSmith;
    private CustomerData _link;

    private void Start()
    {
        SecureCustomerData();
    }

    public void SecureCustomerData()
    {
        _johnSmith = new CustomerData("John", "Smith", 31, CustomerData.Gender.male, "Mechanic");
        _janeSmith = new CustomerData("Jane", "Smith", 31, CustomerData.Gender.female, "Software Development");
        _link = new CustomerData("Link", "Unknown", 20, CustomerData.Gender.male, "Hero of Hyruke");
    }
}
