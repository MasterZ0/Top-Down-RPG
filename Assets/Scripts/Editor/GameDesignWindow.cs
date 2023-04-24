using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Z3.UIBuilder.Editor;
using Z3.UIBuilder.Core;
using Z3.UIBuilder;
using BG.Items;
using UnityEngine.UIElements;

namespace BG.Editor
{
    public class GameDesignWindow : ObjectMenuWindow<ScriptableObject>
    {
        [SerializeField] private VisualTreeAsset visualTreeAsset;

        protected override VisualTreeAsset VisualTreeAsset => visualTreeAsset;

        [MenuItem("Blue Gravity/Game Design")]
        public static void ShowWindow()
        {
            GetWindow<GameDesignWindow>("Game Design");
        }

        //[OnOpenAsset]
        //public static bool OpenEditor(int instanceId, int line)
        //{
        //    if (EditorUtility.InstanceIDToObject(instanceId) is GameData)
        //    {
        //        ShowWindow();
        //        return true;
        //    }
        //    return false;
        //}

        protected override void BuildMenuTree(TreeMenu<ScriptableObject> tree)
        {
            //GameData gameData = AssetDatabase.LoadAssetAtPath<GameData>(DemoPaths.GameDataAsset);

            //tree.AddGameData("Game Data", gameData);

            tree.AddAllAssetsAtPath($"Game Data/Items", $"Assets/Data/Items", typeof(ItemData), true, IconType.Gamepad);
        }

        protected override void OnChangeSelection(ScriptableObject selectedObject)
        {
            // TODO: If is Scriptable Object, show ping
        }

        [UIElement("pingObject")]
        private void OnPingObject() => EditorGUIUtility.PingObject(SelectedObject);
    }
}
    