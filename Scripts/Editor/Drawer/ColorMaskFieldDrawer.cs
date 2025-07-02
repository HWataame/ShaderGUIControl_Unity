/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
マテリアルのプロパティ上でカラーマスクのフィールドを描画するクラス

ColorMaskFieldDrawer.cs
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
    /// マテリアルのプロパティ上でカラーマスクのフィールドを描画するクラス
    /// </summary>
    /// <remarks>カラーマスクのプロパティに[ColorMaskField]を付与すると使用可能</remarks>
    internal sealed class ColorMaskFieldDrawer : MaterialPropertyDrawer
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

            // カラーマスクのボタンを描画できるようにラベルの幅を一時的に調整する
            using (new LabelWidthScope(position.width - 64 - 34 * 3))
            {
                // カラーマスクのフィールドを描画する
                ColorMaskGUI.ColorMaskField(position, prop, label);
            }
        }
    }
}
