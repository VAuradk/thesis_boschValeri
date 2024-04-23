using System.Collections.Generic;
using UnityEngine;

public class TagManagement : MonoBehaviour
{
    private Dictionary<string, List<string>> tagCategories = new Dictionary<string, List<string>>();

    private void Awake()
    {
        InitializeCategories();
    }

    private void InitializeCategories()
    {
        string[] allTags = UnityEditorInternal.InternalEditorUtility.tags;

        foreach (string tag in allTags)
        {
            string category = GetCategoryForTag(tag);

            if (!tagCategories.ContainsKey(category))
            {
                tagCategories.Add(category, new List<string>());
            }
            tagCategories[category].Add(tag);
        }
    }

    private string GetCategoryForTag(string tag)
    {
        if (tag.StartsWith("enemy"))
        {
            return "Enemies";
        }

        if (tag.StartsWith("collision"))
        {
            return "Collisions";
        }

        if (tag.StartsWith("player"))
        {
            return "PlayerMode";
        }
        return "Other";
    }

    public bool IsInTagCategory(string tag, string category)
    {
        if (tagCategories.ContainsKey(category))
        {
            List<string> tagsInCategory = tagCategories[category];
            return tagsInCategory.Contains(tag);
        }
        else
        {
            Debug.LogWarning($"Category '{category}' not found.");
            return false;
        }
    }

    public Transform GetTransformWithTag(string tag)
    {
        GameObject taggedObject = GameObject.FindGameObjectWithTag(tag);
        if (taggedObject != null)
        {
            return taggedObject.transform;
        }
        else
        {
            Debug.LogWarning($"Object with tag '{tag}' not found.");
            return null;
        }

    }
}
