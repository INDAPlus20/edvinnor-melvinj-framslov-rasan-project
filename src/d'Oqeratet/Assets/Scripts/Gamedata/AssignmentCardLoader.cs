using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class AssignmentCardLoader
{
    private List<AssignmentCard> all_assignments; 

    public AssignmentCardLoader (string path) 
    {
        all_assignments = new List<AssignmentCard>();

        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("This");
                sw.WriteLine("Is");
                sw.WriteLine("Supposed");
                sw.WriteLine("To");
                sw.WriteLine("Be");
                sw.WriteLine("An");
                sw.WriteLine("Assignment");
            }
        }

        // Open the file to read from since it exists
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Debug.Log(s);
            }
        }

    }
}
