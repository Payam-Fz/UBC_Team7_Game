using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour
{
    #region Main Tree
    public static DiagnosisTreeNode tree =
    new DiagnosisTreeNode("Start", "Start Diagnosis")
    {
        new DiagnosisTreeNode("Illness", "An Illness")
        {
          new DiagnosisTreeNode("Generalized", "In a general area of the body")
          {
            new DiagnosisTreeNode("Skin", "The Skin", true)
            {
                new DiagnosisTreeNode("Infection", "An infection"),
                new DiagnosisTreeNode("Cancer", "A Cancer"),
                new DiagnosisTreeNode("Genetic", "A genetically predisposed illness"),
                new DiagnosisTreeNode("Induced", "An induced illness")
            },
            new DiagnosisTreeNode("Joint", "Joints", true)
            {
                new DiagnosisTreeNode("Infection", "An infection"),
                new DiagnosisTreeNode("Cancer", "A Cancer"),
                new DiagnosisTreeNode("Genetic", "A genetically predisposed illness"),
                new DiagnosisTreeNode("Induced", "An induced illness")
            },
            new DiagnosisTreeNode("Nerve", "Parts of the nervous system", true)
            {
                new DiagnosisTreeNode("Infection", "An infection"),
                new DiagnosisTreeNode("Cancer", "A Cancer"),
                new DiagnosisTreeNode("Genetic", "A genetically predisposed illness"),
                new DiagnosisTreeNode("Induced", "An induced illness")
            }
          },
          new DiagnosisTreeNode("Localized", "In a certain part of the body", true)
          {
            new DiagnosisTreeNode("System Picker", "Shift to visual picker"),
          },
        },
        new DiagnosisTreeNode("Injury", "An Injury")
        {
          new DiagnosisTreeNode("Burn", "A burn caused by external heat", true)
          {
            new DiagnosisTreeNode("First Degree", "These are mild compared to other burns, they cause pain and reddening to the outer layer of the skin"),
            new DiagnosisTreeNode("Second Degree", "These affect the outer and lower layer of skin, causing pain, redness, swelling, and blistering"),
            new DiagnosisTreeNode("Third Degree", "These go through the layers of skin and affect the deeper tissues, they can result in white or blackened, " +
                "charred skin that may be numb")
          },
          new DiagnosisTreeNode("Fracture", "A broken bone or smth oof", true)
          {
              new DiagnosisTreeNode("Fracture", "Definitely a broken bone or smth")
          },
          new DiagnosisTreeNode("Soft Tissue Damage", "Damage to the soft tissue underneath the skin")
          {
              new DiagnosisTreeNode("Skin", "The outermost layer of the body", true)
              {
                  new DiagnosisTreeNode("Laceration", "cut owie"),
                  new DiagnosisTreeNode("Perforation", "too many circles please stop"),
                  new DiagnosisTreeNode("Contusion", "this is contusing")
              },
              new DiagnosisTreeNode("Internal Organ", "Inside the body", true)
              {
                  new DiagnosisTreeNode("System Picker", "Shift to System Picker")
              }
          }
        },
    };
    #endregion
}
