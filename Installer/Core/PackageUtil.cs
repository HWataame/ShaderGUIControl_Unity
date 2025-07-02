/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
所定のパッケージをインストールするクラス

PackageUtil.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.GitPackageInstaller.Core.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
#pragma warning disable IDE0063

namespace HW.GitPackageInstaller.Core
{
    /// <summary>
    /// 所定のパッケージをインストールするクラス
    /// </summary>
    internal static class PackageUtil
    {
        /// <summary>
        /// package.jsonから必要な情報を取得するためのクラス
        /// </summary>
        [Serializable]
        private class PackageJsonInformation
        {
            /// <summary>
            /// パッケージ名
            /// </summary>
            [SerializeField]
            private string name;

            /// <summary>
            /// パッケージ名
            /// </summary>
            public string Name
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => name;
            }
        }


        /// <summary>
        /// パッケージのインストールを登録する
        /// </summary>
        [InitializeOnLoadMethod]
        private static void RegisterInstall()
        {
            EditorApplication.delayCall += async () => await InstallPackages();
        }

        /// <summary>
        /// パッケージをインストールする
        /// </summary>
        /// <returns></returns>
        private static async ValueTask InstallPackages()
        {
            // 進捗バーを表示する
            EditorUtility.DisplayProgressBar(
                "Git Package Installer", "インストールに必要なデータを収集しています", 0);

            // このソースコードはパッケージのルートから1階層下のディレクトリに存在する
            // (root/Core/PackageUtil.cs)ため、2回親ディレクトリを取得する
            var packageRootPath = GetParentPath(GetParentPath(GetSelfPath())).Replace('\\', '/');

            // 自身のパッケージ名を取得する
            var packageName = await GetSelfPackageName(packageRootPath);
            if (string.IsNullOrWhiteSpace(packageName))
            {
                // 自身のパッケージ名を取得できなかった場合は失敗
                Debug.LogError("[Git Package Installer] パッケージのインストールに失敗しました");
                EditorUtility.ClearProgressBar();

                return;
            }

            // 進捗バーの内容を書き換える
            EditorUtility.DisplayProgressBar($"Git Package Installer ({packageName})",
                "インストールするパッケージを取得しています", 1f / 3);

            // Git URLを取得する
            var gitUrl = await GetGitUrl(packageName);

            if (string.IsNullOrEmpty(gitUrl))
            {
                // 完了した旨を1秒表示する
                EditorUtility.DisplayProgressBar($"Git Package Installer ({packageName})",
                    "パッケージのインストールが完了しました", 1);
                await Task.Delay(1000);

                // 進捗バーを消す
                EditorUtility.ClearProgressBar();

                // インストーラー(自身)を除去する
                await WaitRequest(Client.Remove(packageName));
                return;
            }

            // 進捗バーを消す
            EditorUtility.ClearProgressBar();

            // リポジトリからパッケージを取得する
            await WaitRequest(Client.Add(gitUrl));
        }

        /// <summary>
        /// 自身のパスを取得する
        /// </summary>
        /// <param name="doNotAssign">コンパイル時に呼び出し元ソースのパスが入る</param>
        /// <returns>自身のパス</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetSelfPath([CallerFilePath] string doNotAssign = null)
        {
            return doNotAssign;
        }

        /// <summary>
        /// 親ディレクトリのパスを取得する
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>親ディレクトリのパス</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetParentPath(string path)
        {
            ReadOnlySpan<char> pathSpan = path;
            for (int i = pathSpan.Length - 1; i >= 0; --i)
            {
                if (pathSpan[i] == '/' || pathSpan[i] == '\\')
                {
                    // パスの区切り文字の前までの文字列を返す
                    return path[..i];
                }
            }

            // パスの区切り文字が存在しない場合は入力文字列をそのまま返す
            return path;
        }

        /// <summary>
        /// 自身のパッケージ名を取得する
        /// </summary>
        /// <param name="packageRootPath">パッケージのルートパス</param>
        /// <returns>パッケージ名</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static async ValueTask<string> GetSelfPackageName(string packageRootPath)
        {
            var packageJsonPath = Path.GetFullPath(packageRootPath + "/package.json");
            if (!File.Exists(packageJsonPath))
            {
                // package.jsonが存在しない場合は失敗
                return null;
            }

            using (var fs = new FileStream(packageJsonPath, FileMode.Open, FileAccess.Read))
            {
                // package.jsonの内容を読み込む
                byte[] data = new byte[(int)fs.Length];
                await fs.ReadAsync(data, 0, data.Length);

                // package.jsonを解釈する
                var json = Encoding.UTF8.GetString(data);
                var parsed = JsonUtility.FromJson<PackageJsonInformation>(json);

                // package.jsonを解釈できた場合はnameの値を、できなかった場合はnullを返す
                return parsed?.Name;
            }
        }

        /// <summary>
        /// Git URLを取得する
        /// </summary>
        /// <param name="packageName">パッケージ名</param>
        /// <returns>null=失敗、空文字列=処理終了、それら以外=Git URL</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async ValueTask<string> GetGitUrl(string packageName)
        {
            // リポジトリのテーブルを取得する
            var table = AssetDatabase.LoadAssetAtPath<GitRepositoryTable>($"Packages/{packageName}/repotbl.asset");
            if (!table) return null;

            // レコードを取得する
            var records = new List<GitRepositoryRecord>(table);

            // プロジェクトのパッケージ情報を取得する
            var packages = await WaitRequest(Client.List());
            if (packages == null) return null;

            foreach (var package in packages)
            {
                for (int i = records.Count - 1; i >= 0; --i)
                {
                    var record = records[i];
                    if (record.PackageName == package.name &&
                        (string.IsNullOrWhiteSpace(record.GuidCheckPath) ||
                        string.IsNullOrWhiteSpace(record.Guid) ||
                        AssetDatabase.GUIDFromAssetPath(record.GuidCheckPath).ToString() == record.Guid))
                    {
                        // 判定をしない／GUIDの判定を行い、GUIDが同じである場合は対象から外す
                        records.RemoveAt(i);
                    }
                }
            }

            // 追加対象が存在しない場合
            if (records.Count == 0) return "";

            // 追加対象が存在する場合
            return records[0].GitUrl;
        }

        /// <summary>
        /// リクエストを待機する
        /// </summary>
        /// <param name="request">リクエスト</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async ValueTask<bool> WaitRequest(Request request)
        {
            // タスクの終了を待機する
            while (!request.IsCompleted) await Task.Yield();

            return request.Status == StatusCode.Success;
        }

        /// <summary>
        /// 結果つきのリクエストを待機する
        /// </summary>
        /// <typeparam name="T">結果の型</typeparam>
        /// <param name="request">リクエスト</param>
        /// <returns>結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static async ValueTask<T> WaitRequest<T>(Request<T> request)
        {
            // タスクの終了を待機する
            while (!request.IsCompleted) await Task.Yield();

            if (request.Status == StatusCode.Success)
            {
                // 読み込めた場合
                return request.Result;
            }
            else
            {
                // 読み込みに失敗した場合
                return default;
            }
        }
    }
}
