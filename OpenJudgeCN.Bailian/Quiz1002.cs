﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenJudgeCN.Bailian
{
    public class Quiz1002
    {
        public const string Introduce =
      @"描述
        英文字母（除Q和Z外）和电话号码存在着对应关系，如下所示：
        A,B,C -> 2
        D,E,F -> 3
        G,H,I -> 4
        J,K,L -> 5
        M,N,O -> 6
        P,R,S -> 7
        T,U,V -> 8
        W,X,Y -> 9
        标准的电话号码格式是xxx-xxxx，其中x表示0-9中的一个数字。有时为了方便记忆电话号码，我们会将电话号码的数字转变为英文字母，
        如把263-7422记成America。有时，我们还加上“-”作为分隔符，如把449-6753记成Hi-World。当然，我们未必要将所有的数字都转变为字母，
        比如474-6635可以记成iPhone-5。
        总之，一个方便记忆的电话号码由数字和除Q、Z外的英文字母组成，并且可以在任意位置插入任意多的“-”符号。
        现在 ，我们有一个列表，记录着许多方便记忆的电话号码。不同的方便记忆的电话号码可能对应相同的标准号码，你的任务就是找出它们。

        输入
        第一行是一个正整数n（n <= 100000），表示列表中的电话号码数。
        其后n行，每行是一个方便记忆的电话号码，它由数字和除Q、Z外的英文字母、“-”符号组成，其中数字和字母的总数一定为7，字符串总长度不超过200。

        输出
        输出包括若干行，每行包括一个标准电话号码（xxx-xxxx）以及它重复出现的次数k（k >= 2），中间用空格分隔。输出的标准电话号码需按照升序排序。
        如果没有重复出现的标准电话号码，则输出一行“No duplicates.”。

        样例输入
        12
        4873279
        ITS-EASY
        888-4567
        3-10-10-10
        888-GLOP
        TUT-GLOP
        967-11-11
        310-GINO
        F101010
        888-1200
        -4-8-7-3-2-7-9-
        487-3279

        样例输出
        310-1010 2
        487-3279 4
        888-4567 3";

        private static readonly Dictionary<char, char> ConvertDict = new Dictionary<char, char>
        {
            {'A', '2'}, {'B', '2'}, {'C', '2'},
            {'D', '3'}, {'E', '3'}, {'F', '3'},
            {'G', '4'}, {'H', '4'}, {'I', '4'},
            {'J', '5'}, {'K', '5'}, {'L', '5'},
            {'M', '6'}, {'N', '6'}, {'O', '6'},
            {'P', '7'}, {'R', '7'}, {'S', '7'},
            {'T', '8'}, {'U', '8'}, {'V', '8'},
            {'W', '9'}, {'X', '9'}, {'Y', '9'}
        };

        public static void Test()
        {
            var count = int.Parse(Console.ReadLine());
            var inputList = new List<string>(count);
            for (var i = 0; i < count; ++i)
                inputList.Add(Console.ReadLine());

            for (var i = 0; i < inputList.Count; ++i)
                inputList[i] = ConvertToPhoneNumber(inputList[i]);

            var set = new HashSet<string>();
            var dict = new Dictionary<string, int>();
            foreach (var input in inputList)
                if (set.Add(input))
                    dict.Add(input, 1);
                else
                    ++dict[input];

            Console.WriteLine();

            if (dict.Count == inputList.Count)
                Console.WriteLine("No duplicates.");
            else
                foreach (var pair in dict.Where(o => o.Value > 1).OrderBy(o => o.Key))
                    Console.WriteLine($"{pair.Key.Insert(3, "-")} {pair.Value}");
        }

        private static string ConvertToPhoneNumber(string str)
        {
            str = str.Replace("-", "");
            var res = new StringBuilder(7);
            for (var i = 0; i < 7; ++i)
                res.Append(ConvertDict.TryGetValue(str[i], out var converted) ? converted : str[i]);

            return res.ToString();
        }
    }
}