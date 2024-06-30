using UnityEngine;
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
        tagCategories.Add("Enemies", new List<string> { "enemyBasic", "enemyChase", "enemyCreeper", "enemyInvisible", "enemyRandom", "enemyFire" });
        tagCategories.Add("Collisions", new List<string> { "collisionWall", "collisionTrap", "collisionBreakableWall" });
        tagCategories.Add("PlayerMode", new List<string> { "playerNormalMode", "playerGodMode" });
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
