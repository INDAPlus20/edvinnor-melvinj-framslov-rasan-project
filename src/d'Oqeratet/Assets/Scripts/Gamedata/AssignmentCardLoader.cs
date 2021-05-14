using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class AssignmentCardLoader
{
    public static void Write15RandomAssignments (string path) 
    {
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 15; i++) {
                    AssignmentCard card = ScriptableObject.CreateInstance<AssignmentCard>();
                    string json = card.ToJson();
                    sw.WriteLine(json);
                }
            }
        }
    }

    public static List<AssignmentCard> ReadAssignments (string path) {
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 15; i++) {
                    AssignmentCard card = ScriptableObject.CreateInstance<AssignmentCard>();
                    string json = card.ToJson();
                    sw.WriteLine(json);
                }
            }
        }

        // Open the file to read from since it exists
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            List<AssignmentCard> assignments = new List<AssignmentCard>();
            while ((s = sr.ReadLine()) != null)
            {
                AssignmentCard readcard = ScriptableObject.CreateInstance<AssignmentCard>();
                JsonUtility.FromJsonOverwrite(s, readcard);
                assignments.Add(readcard);
            }
            return assignments;
        }
    }
}
