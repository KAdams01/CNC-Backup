using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StrikeThrough
{
    public static string StrikeThroughText(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }
}
