using UnityEditor;
using UnityEngine;
using Z3.UIBuilder.Editor;
using Z3.UIBuilder.Core;
using Z3.UIBuilder;
using TD.Items;
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

        protected override void BuildMenuTree(TreeMenu<ScriptableObject> tree)
        {
            tree.AddAllAssetsAtPath($"Items", $"{MenuPath.DataFolder}/Items", typeof(ItemData), true, IconType.Gamepad);
            tree.AddAllAssetsAtPath($"NPCs", $"{MenuPath.DataFolder}/NPCs", typeof(ScriptableObject), true, IconType.Gamepad);
            tree.AddAllAssetsAtPath($"Player", $"{MenuPath.DataFolder}/Player", typeof(ScriptableObject), true, IconType.Gamepad);
        }

        [UIElement("pingObject")]
        private void OnPingObject() => EditorGUIUtility.PingObject(SelectedObject);
    }
}
    