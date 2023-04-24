using System.IO;
using TD.Character;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace TD.Editor
{
    using MenuPath = Shared.MenuPath;

    public class TopDownEditorWindow : EditorWindow
    {
        [MenuItem(MenuPath.ProjectName + "/Tools")]
        private static void AddComponentToPrefabs()
        {
            GetWindow<TopDownEditorWindow>("Tools");
        }

        private void CreateGUI()
        {
            Button button = new();
            button.text = "Auto Add TopDownSpriteUpdater";

            rootVisualElement.Add(button);

            button.clicked += OnClick;
        }

        private void OnClick()
        {
            // Seleciona uma pasta de prefabs na janela do projeto
            string path = EditorUtility.OpenFolderPanel("Select Prefab Folder", "", "");

            int totalItems = 0;
            if (!string.IsNullOrEmpty(path))
            {
                path = "Assets" + Path.GetFullPath(path).Substring(Application.dataPath.Length);
                string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { path });


                foreach (string prefabGuid in guids)
                {
                    string prefabFile = AssetDatabase.GUIDToAssetPath(prefabGuid);

                    // Carrega o prefab em um GameObject
                    GameObject prefab = AssetDatabase.LoadAssetAtPath(prefabFile, typeof(GameObject)) as GameObject;

                    if (prefab != null)
                    {
                        if (prefab.TryGetComponent(out SpriteRenderer prefabSpriteRenderer))
                        {
                            TryAddUpdater(prefabSpriteRenderer, ref totalItems);
                        }

                        // Verifica se o prefab tem um SpriteRenderer no objeto ou em um dos filhos
                        SpriteRenderer[] spriteRenderers = prefab.GetComponentsInChildren<SpriteRenderer>(true);

                        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                        {
                            TryAddUpdater(spriteRenderer, ref totalItems);
                        }
                    }
                }

                Debug.Log($"Totalof TopDownSpriteUpdater added: {totalItems}");

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
            
        private void TryAddUpdater(SpriteRenderer spriteRenderer, ref int totalItems)
        {
            if (!spriteRenderer.TryGetComponent(out TopDownSpriteUpdater _))
            {
                // Adiciona o componente TopDownSpriteUpdater ao prefab
                spriteRenderer.gameObject.AddComponent<TopDownSpriteUpdater>();
                Debug.Log($"Added TopDownSpriteUpdater to prefab: {spriteRenderer.name}");
                totalItems++;
            }
        }
    }
}
    