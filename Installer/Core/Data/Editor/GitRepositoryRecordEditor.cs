/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
GitRepositoryRecordのインスペクターを描画するクラス

PackageUtil.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;
using UnityEditor;
using UnityEngine;

namespace HW.GitPackageInstaller.ComHwShaderGuiControlInstaller.Core.Data.Editor
{
    /// <summary>
    /// GitRepositoryRecordのインスペクターを描画するクラス
    /// </summary>
    [CustomPropertyDrawer(typeof(GitRepositoryRecord))]
    internal class GitRepositoryRecordEditor : PropertyDrawer
    {
        /// <summary>
        /// 表示内容の配列
        /// </summary>
        private static readonly (GUIContent label, string path)[] Contents = new (GUIContent, string)[]
        {
            (new("Git URL"), "gitUrl"),
            (new("パッケージ名"), "packageName"),
            (new("判定するアセットのパス"), "guidCheckPath"),
            (new("判定するアセットのGUID"), "guid")
        };


        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="position">描画範囲</param>
        /// <param name="property">プロパティ</param>
        /// <param name="label">ラベル</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // 描画範囲を計算する
            var currentRect = position;
            currentRect.height = EditorGUIUtility.singleLineHeight;

            ReadOnlySpan<(GUIContent label, string path)> contents = Contents;
            for (int i = 0; i < contents.Length; ++i)
            {
                // 余白を確保する
                currentRect.y += EditorGUIUtility.standardVerticalSpacing;

                // プロパティを描画する
                var content = contents[i];
                EditorGUI.PropertyField(currentRect,
                    property.FindPropertyRelative(content.path), content.label);

                // 描画したため描画位置を下げる
                currentRect.y += currentRect.height;
            }
        }

        /// <summary>
        /// 描画範囲の高さを取得する
        /// </summary>
        /// <param name="property">プロパティ</param>
        /// <param name="label">ラベル</param>
        /// <returns>描画範囲の高さ</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int count = Contents.Length;
            return EditorGUIUtility.singleLineHeight * count +
                EditorGUIUtility.standardVerticalSpacing * (count + 1);
        }
    }
}
