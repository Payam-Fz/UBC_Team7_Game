using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosisTreeNode : IEnumerable<DiagnosisTreeNode>
{
    private readonly Dictionary<string, DiagnosisTreeNode> mChildren_ =
                                        new Dictionary<string, DiagnosisTreeNode>();

    public readonly string name;
    public readonly string description;
    public DiagnosisTreeNode Parent { get; private set; }
    public bool isFinal;

    public DiagnosisTreeNode(string id, string desc)
    {
        this.name = id;
        this.description = desc;
        this.isFinal = false;
    }

    public DiagnosisTreeNode(string id, string desc, bool isFinal)
    {
        this.name = id;
        this.description = desc;
        this.isFinal = isFinal;
    }

    public DiagnosisTreeNode GetChild(string name)
    {
        return this.mChildren_[name];
    }

    public string GetDiagnosis()
    {
        return this.isFinal ? (this.GetChildren())[0] : "Not Allowed to get diagnosis at a non-final node";
    }

    public List<string> GetChildren()
    {
        return new List<string>(this.mChildren_.Keys);
    }

    public void Add(DiagnosisTreeNode item)
    {
        if (item.Parent != null)
        {
            item.Parent.mChildren_.Remove(item.name);
        }

        item.Parent = this;
        this.mChildren_.Add(item.name, item);
    }

    public IEnumerator<DiagnosisTreeNode> GetEnumerator()
    {
        return this.mChildren_.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count
    {
        get { return this.mChildren_.Count; }
    }
}
