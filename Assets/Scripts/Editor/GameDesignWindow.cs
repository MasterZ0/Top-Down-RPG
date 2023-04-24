using UnityEditor;
using UnityEngine;
using Z3.UIBuilder.Editor;
using Z3.UIBuilder.Core;
using Z3.UIBuilder;
using TD.Items;
using TD.Data;
using UnityEditor.Callbacks;
using UnityEngine.UIElements;

namespace TD.Editor
{
    using MenuPath = Shared.MenuPath;

    public class GameDesignWindow : ObjectMenuWindow<ScriptableObject>
    {
        [SerializeField] private VisualTreeAsset visualTreeAsset;

        protected override VisualTreeAsset VisualTreeAsset => AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Plugins/Z3/ObjectMenuVT.uxml");

        [MenuItem(MenuPath.ProjectName + "/Game Design")]
        public static void ShowWindow()
        {
            GetWindow<GameDesignWindow>("Game Design");
        }

        [OnOpenAsset]
        public static bool OpenEditor(int instanceId, int line)
        {
            if (EditorUtility.InstanceIDToObject(instanceId) is GameData)
            {
                ShowWindow();
                return true;
            }
            return false;
        }

        protected override void BuildMenuTree(TreeMenu<ScriptableObject> tree)
        {
            GameData gameData = AssetDatabase.LoadAssetAtPath<GameData>(MenuPath.GameData);

            tree.AddGameData("Game Data", gameData);

            tree.AddAllAssetsAtPath($"Game Data/Items", $"{MenuPath.DataFolder}/Items", typeof(ItemData), true, IconType.Gamepad);
        }

        [UIElement("pingObject")]
        private void OnPingObject() => EditorGUIUtility.PingObject(SelectedObject);
    }
}
    