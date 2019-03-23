using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresult = string.Empty;
            while (true)
            {
                Console.WriteLine("请输入计算式:");
                List<string> rebuildExp = ReturnrebuildExp(Console.ReadLine());
                List<string> chengchuExp = new List<string>();
                List<string> jiajianExp = new List<string>();
                int tempValue = 0;
                //先算乘除并添加到乘除队列里 
                for (int i = 0; i < rebuildExp.Count; i++)
                {
                    if (int.TryParse(rebuildExp[i].ToString(), out tempValue))
                    {
                        chengchuExp.Add(rebuildExp[i]);
                    }
                    else
                    {
                        if (rebuildExp[i] == "*" || rebuildExp[i] == "/")
                        {
                            expresult = GetR(chengchuExp[chengchuExp.Count - 1], rebuildExp[i], rebuildExp[i + 1]);
                            chengchuExp.RemoveAt(chengchuExp.Count - 1);
                            chengchuExp.Add(expresult);
                            i++;
                        }
                        else
                        {
                            chengchuExp.Add(rebuildExp[i]);
                        }
                    }
                }
                //后算加减并添加到加减队列里
                for (int i = 0; i < chengchuExp.Count; i++)
                {
                    if (int.TryParse(chengchuExp[i].ToString(), out tempValue))
                    {
                        jiajianExp.Add(chengchuExp[i]);
                    }
                    else
                    {
                        if (chengchuExp[i] == "+" || chengchuExp[i] == "-")
                        {
                            expresult = GetR(jiajianExp[jiajianExp.Count - 1], chengchuExp[i], chengchuExp[i + 1]);
                            jiajianExp.RemoveAt(jiajianExp.Count - 1);
                            jiajianExp.Add(expresult);
                            i++;
                        }
                        else
                        {
                            jiajianExp.Add(chengchuExp[i]);
                        }
                    }
                }
                string finalexp = string.Empty;
                Console.WriteLine("计算结果为:{0}", jiajianExp[0]);
                rebuildExp.Clear();
                chengchuExp.Clear();
                jiajianExp.Clear();
            }
        }
        //返回重组后的计算式
        public static List<string> ReturnrebuildExp(string exp)
        {
            List<string> rebuildExp = new List<string>();
            int tempValue = 0;
            string temp = string.Empty;
            for (int i = 0; i < exp.Length; i++)
            {
                if (int.TryParse(exp[i].ToString(), out tempValue))
                {
                    temp += exp[i].ToString();
                }
                else
                {
                    rebuildExp.Add(temp);
                    temp = string.Empty;
                    rebuildExp.Add(exp[i].ToString());
                }
            }
            rebuildExp.Add(temp);
            return rebuildExp;

        }
        //得出结果
        public static string GetR(string a, string sign, string b)
        {
            string ReturnValue = string.Empty;
            int x = Convert.ToInt32(a.ToString());
            int y = Convert.ToInt32(b.ToString());
            switch (sign)
            {
                case "+": ReturnValue = (x + y).ToString(); break;
                case "-": ReturnValue = (x - y).ToString(); break;
                case "*": ReturnValue = (x * y).ToString(); break;
                case "/": ReturnValue = (x / y).ToString(); break;
            }
            return ReturnValue;
        }
    }
}
