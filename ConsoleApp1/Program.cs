//--------------------------------------------------
//
// メイン処理 [ Program.cs ]
// Author:Kenta Nakamoto
// Data 2024/06/14
//
//--------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //--------------------------------------------
        // フィールド

        // 最大カード数
        private const int MAX_CARD_NUM = 4;

        //--------------------------------------------
        // メソッド

        static void Main(string[] args)
        {
            // 入力数値格納用
            int[] cardNums = new int[MAX_CARD_NUM];

            // ペア数格納用
            int pairNum;

            for (int i = 0; i < MAX_CARD_NUM; i++)
            {   // カードの最大数分入力させる
                cardNums[i] = new int();
                cardNums[i] = InputCardNum();
            }
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
    }
}
