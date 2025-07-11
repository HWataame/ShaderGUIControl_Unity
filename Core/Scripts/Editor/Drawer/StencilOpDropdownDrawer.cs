/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
マテリアルのプロパティ上でステンシル処理設定のドロップダウンを描画するクラス

StencilOpDropdownDrawer.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.GUIScopes;
using HW.ShaderDropdown.Editor.GUIs;
using UnityEditor;
using UnityEngine;

namespace HW.ShaderDropdown.Editor.Drawer
{
    /// <summary>
    /// マテリアルのプロパティ上でステンシル処理設定のドロップダウンを描画するクラス
    /// </summary>
    /// <remarks>プロパティに[StencilOpDropdown]を付与すると使用可能</remarks>
    internal sealed class StencilOpDropdownDrawer : MaterialPropertyDrawer
    {
        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="position">描画範囲</param>
        /// <param name="prop">プロパティ</param>
        /// <param name="label">ラベル</param>
        /// <param name="editor">マテリアルエディター</param>
        public sealed override void OnGUI(Rect position, MaterialProperty prop, GUIContent label, MaterialEditor editor)
        {
            // ラベルがnullである場合は失敗
            if (label == null) return;

            // ラベルの幅を一時的に調整する
            using (new LabelWidthScope(position.width - 244))
            {
                // ステンシル処理設定のフィールドを描画する
                StencilOpGUI.StencilOpDropdown(position, prop, label);
            }
        }
    }
}
