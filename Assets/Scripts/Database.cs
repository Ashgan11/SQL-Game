using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct demoDB{
    public int CustomerID;
    public string CustomerName, ContactName, Address, City, PostalCode, Country;

    public demoDB(int id, string custname, string contact, string address, string city, string postal, string country){
        CustomerID = id;
        CustomerName = custname;
        ContactName = contact;
        Address = address;
        City = city;
        PostalCode = postal;
        Country = country;
    }

    public override string ToString()
    {
        string output = default;
        output += CustomerID.ToString() + '\t';
        output += CustomerName + '\t';
        output += ContactName + '\t';
        output += Address + '\t';
        output += City + '\t';
        output += PostalCode + '\t';
        output += Country + '\t';

        return output;
    }
}

public class Database
{    
    private LinkedList<demoDB> DEMO = new LinkedList<demoDB>();

    public Database(){
        DEMO.AddLast(new demoDB(
            1,
            "Alfreds Futterkiste",
            "Maria Anders",
            "Obere Str. 57",
            "Berlin",
            "12209",
            "Germany"
        ));
        DEMO.AddLast(new demoDB(
            2,
            "Ana Trujillo Emparedados y helados",
            "Ana Trujillo",
            "Avda. de la Constitución 2222",
            "México D.F.",
            "05021",
            "Mexico"
        ));
        DEMO.AddLast(new demoDB(
            3,
            "Antonio Moreno Taquería",
            "Antonio Moreno",
            "Mataderos 2312",
            "México D.F.",
            "05023",
            "Mexico"
        ));
        DEMO.AddLast(new demoDB(
            4,
            "Around the Horn",
            "Thomas Hardy",
            "120 Hanover Sq.",
            "London",
            "WA1 1DP",
            "UK"
        ));
        DEMO.AddLast(new demoDB(
            5,
            "Berglunds snabbköp",
            "Christina Berglund",
            "Berguvsvägen 8",
            "Luleå",
            "S-958 22",
            "Sweden"
        ));
    }

    public override string ToString()
    {
        string output = default;
        foreach (demoDB row in DEMO){
            output += row.ToString() + '\n';
        }        
        return output;
    }
}
