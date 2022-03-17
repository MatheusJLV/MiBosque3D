using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile
{
    public string name;
    public int edad;
    public string character;

    public PlayerProfile()
    {
    }

    public PlayerProfile(string name, int edad, string character)
    {
        this.name = name;
        this.edad = edad;
        this.character = character;
    }

    override
    public string ToString()
    {
        return name + edad + character;
    }

    
}
