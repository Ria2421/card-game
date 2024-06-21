//--------------------------------------------------
//
// メイン処理 [ Program.cs ]
// Author:Kenta Nakamoto
// Data 2024/06/21
//
//--------------------------------------------------
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //--------------------------------------------
        // フィールド

        /// <summary>
        /// 最大カード数
        /// </summary>
        private const int MAX_CARD_NUM = 4;

        //--------------------------------------------
        // メソッド

        /// <summary>
        /// メイン処理
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                // 入力数値格納用
                List<int> numList = new List<int>();

                // 一致数格納用
                List<int> matchCntList = new List<int>();

                // カードの最大数分入力させる
                for (int i = 0; i < MAX_CARD_NUM; i++)
                {
                    numList.Add(InputCardNum());
                }

                // 改行
                Console.WriteLine();

                // ペア数の取得処理
                for (int i = 0; i < MAX_CARD_NUM; i++)
                {
                    // 一致する値のリストを生成
                    List<int> findList1 = numList.FindAll(n => n == numList[i]);

                    // 生成したリストの長さを取得
                    matchCntList.Add(findList1.Count);
                }

                // 結果判定・表示
                OutputResult(matchCntList);

                // 改行
                Console.WriteLine();

                if (CheckRetry())
                {
                    // 改行
                    Console.WriteLine("\n"); 
                    continue;
                }
                else
                {
                    break;
                }
            }

            // 終了処理
            Console.WriteLine("");
            Console.Write("Enterを押して終了...");
            Console.ReadLine();
        }

        /// <summary>
        /// 数値入力処理
        /// </summary>
        /// <returns>入力された数値</returns>
        private static int InputCardNum()
        {
            int cardNum = 0;

            while (true)
            {
                // 体力の入力
                Console.Write("■ 数値を入力 (1～13) > ");
                string str = Console.ReadLine();

                if (!int.TryParse(str, out cardNum))
                {   // 数字じゃない時
                    Console.WriteLine("入力された値が数字ではありませんでした。");
                    continue;
                }

                // 数値が範囲内かチェック
                if(0 < cardNum && cardNum <= 13)
                {
                    // 問題なければループ脱出
                    break;
                }
                else
                {
                    Console.WriteLine("入力された値が範囲内ではありませんでした。");
                }
            }

            return cardNum;
        }

        /// <summary>
        /// 結果表示処理
        /// </summary>
        /// <param name="list">一致結果</param>
        private static void OutputResult(List<int> list) 
        {
            // ペア数毎の表示処理
            switch (list.Max())
            {
                case 1:
                    Console.WriteLine("ノーペア...");
                    break;

                case 2:
                    if (list.FindAll(n => n == 2).Count == 4)
                    {
                        Console.WriteLine("ツーペア！");
                        break;
                    }

                    Console.WriteLine("ワンペア");
                    break;

                case 3:
                    Console.WriteLine("スリーカード！");
                    break;

                case 4:
                    Console.WriteLine("フォーカード！");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// リトライ処理
        /// </summary>
        /// <returns></returns>
        private static bool CheckRetry()
        {
            while (true)
            {
                // 回答の入力
                Console.Write("■ もう一度遊びますか？ 1:Yes 2:No > ");
                string str = Console.ReadLine();

                if (!int.TryParse(str, out int answer))
                {   // 数字じゃない時
                    Console.WriteLine("入力された値が数字ではありませんでした。");
                    continue;
                }

                // 数値が範囲内かチェック
                if (answer == 1)
                {
                    return true;
                }
                else if (answer == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("入力された値が範囲内ではありませんでした。");
                }
            }
        }
    }
}
