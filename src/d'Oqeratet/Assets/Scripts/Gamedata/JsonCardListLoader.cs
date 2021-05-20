using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class JsonCardListLoader
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

    public static List<AssignmentCard> ReadPathToAssignmentCardList (string path) {
        if (!File.Exists(path))
        {
            // Create a file to write to.
            // File does not exist
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 15; i++) {
                    AssignmentCard ac = ScriptableObject.CreateInstance<AssignmentCard>();
                    string json = ac.ToJson();
                    sw.WriteLine(json);
                }
            }
        }

        // Open the file to read from since it exists
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            List<AssignmentCard> list = new List<AssignmentCard>();
            while ((s = sr.ReadLine()) != null)
            {
                AssignmentCard readAc = ScriptableObject.CreateInstance<AssignmentCard>();
                JsonUtility.FromJsonOverwrite(s, readAc);
                list.Add(readAc);
            }
            return list;
        }
    }

    public static List<ChapterCard> ReadPathToChapterCardList (string path) {
        if (!File.Exists(path))
        {
            // Create a file to write to.
            // File does not exist
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < 15; i++) {
                    ChapterCard cc = ScriptableObject.CreateInstance<ChapterCard>();
                    string json = cc.ToJson();
                    sw.WriteLine(json);
                }
            }
        }

        // Open the file to read from since it exists
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            List<ChapterCard> list = new List<ChapterCard>();
            while ((s = sr.ReadLine()) != null)
            {
                ChapterCard readCc = ScriptableObject.CreateInstance<ChapterCard>();
                JsonUtility.FromJsonOverwrite(s, readCc);
                list.Add(readCc);
            }
            return list;
        }
    }
}
