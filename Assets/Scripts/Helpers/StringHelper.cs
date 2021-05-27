using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class StringHelper : MonoBehaviour
{
    public static int GetObjectNum(string name)
    {
        if (name.Length == 0)
            return -1;
        return Int32.Parse(Regex.Match(name, @"\d+").Value);
    }
}
