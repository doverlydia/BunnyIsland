using AYellowpaper.SerializedCollections;
using Item;
using Shop;
using System.Linq;
using UnityEditor;
using UnityEngine;
namespace Shop
{
    [CreateAssetMenu(fileName = "ShopModel", menuName = "Shop/ShopModel")]
    class ShopModel : ScriptableObject
    {
        [SerializeField]
        internal ItemDb _itemDb;

        [SerializedDictionary("Item Id", "Price")]
        public SerializedDictionary<string, int> Shop;
    }
}

[CustomEditor(typeof(ShopModel))]
public class ShopModelEditor : Editor
{
    private int selectedIndex = 0;

    public override void OnInspectorGUI()
    {
        ShopModel shopModel = (ShopModel)target;

        DrawDefaultInspector();

        var keys = shopModel?._itemDb?.ItemMap?.Keys.ToList();
        keys?.RemoveAll(x => shopModel.Shop.ContainsKey(x));

        if (shopModel._itemDb != null)
        {
            if (keys?.Count == 0)
            {
                EditorGUILayout.HelpBox("All items in shop, no more to add", MessageType.Info);
            }
            else
            {
                selectedIndex = EditorGUILayout.Popup("Select an Option", selectedIndex, keys.ToArray());

                if (GUILayout.Button("Add Item To Shop"))
                {
                    shopModel.Shop.TryAdd(keys[selectedIndex], 0);
                }
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Must have an ItemDb to select shop items from", MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
