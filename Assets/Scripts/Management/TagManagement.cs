using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TagManagement : MonoBehaviour
{
    private Dictionary<string, List<string>> tagCategories = new Dictionary<string, List<string>>();

    private void Awake()
    {
        InitializeCategories();
    }

    private void InitializeCategories()
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProperty = tagManager.FindProperty("tags");

        for (int i = 0; i < tagsProperty.arraySize; i++)
        {
            string tag = tagsProperty.GetArrayElementAtIndex(i).stringValue;
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
}
