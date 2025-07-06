/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
所定のGitリポジトリのパッケージをインストールするクラス

GitPackageInstaller.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using UnityEditor;

namespace HW.GitPackageInstaller.ComHwShaderGuiControlInstaller.Core
{
    /// <summary>
    /// 所定のGitリポジトリのパッケージをインストールするクラス
    /// </summary>
    internal static class GitPackageInstaller
    {
        /// <summary>
        /// パッケージのインストール処理を登録する
        /// </summary>
        [InitializeOnLoadMethod]
        private static void RegisterGitPackageInstaller()
        {
            // インストール処理を登録する
            EditorApplication.delayCall += async () => await PackageUtil.InstallPackages();
        }
    }
}
