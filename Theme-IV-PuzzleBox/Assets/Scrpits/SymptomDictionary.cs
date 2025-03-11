using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symptomdictionary : MonoBehaviour
{
   static Dictionary<int, string> HeadSymptomDictionary = new Dictionary<int, string>();
   static Dictionary<int, string> BodySymptomDictionary = new Dictionary<int, string>();
   static Dictionary<int, string> TailSymptomDictionary = new Dictionary<int, string>();
   static Dictionary<int, string> LegsSymptomDictionary = new Dictionary<int, string>();
    void Start()
    {
        HeadSymptomDictionary.Add(1, "Fractured Jaw");
        HeadSymptomDictionary.Add(2, "Missing Tooth");
        HeadSymptomDictionary.Add(3, "Injured Eye");
        HeadSymptomDictionary.Add(4, "Brain Damage");

        BodySymptomDictionary.Add(1, "Deep Wounds");
        BodySymptomDictionary.Add(2, "Bleeding");
        BodySymptomDictionary.Add(3, "Infection");
        BodySymptomDictionary.Add(4, "Cuts and Bruises");

        TailSymptomDictionary.Add(1, "Dislocated Bone");
        TailSymptomDictionary.Add(2, "Cut Tail");
        TailSymptomDictionary.Add(3, "Missing Flesh");

        LegsSymptomDictionary.Add(1, "Sprained Ankle");
        LegsSymptomDictionary.Add(2, "Twisted Joint");
        LegsSymptomDictionary.Add(3, "Broken Bone");
    }

    public string BodySymptom()
    {
        return BodySymptomDictionary[Random.Range(1,4)];
    }

    public string HeadSymptom()
    {
        return HeadSymptomDictionary[Random.Range(1, 4)];
    }

    public string TailSymptom()
    {
        return TailSymptomDictionary[Random.Range(1, 3)];
    }

    public string LegsSymptom()
    {
        return LegsSymptomDictionary[Random.Range(1, 3)];
    }

}
