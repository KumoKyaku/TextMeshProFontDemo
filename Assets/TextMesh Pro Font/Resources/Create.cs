using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Changyongzifujizhizuo
{
    class Program
    {
        static void Main(string[] args)
        {
            UnicodeEncoding en = new UnicodeEncoding();
            var f = File.Create("常用字符集.txt");
            StreamWriter wr = new StreamWriter(f, new UTF8Encoding(false));

            ///基本键盘字符
            for (int i = 20; i <= 127; i++)
            {
                char c = (char)i;
                wr.Write(c);
            }
            wr.Write("\n");

            ///基本符号
            for (int i = 8192; i <= 8959; i++)
            {
                char c = (char)i;
                wr.Write(c);
            }
            wr.Write("\n");
            ///标点符号
            for (int i = 12288; i <= 12351; i++)
            {
                char c = (char)i;
                wr.Write(c);
            }
            wr.Write("");
            wr.Write("\n");

            ///日语假名
            for (int i = 12352; i <= 12543; i++)
            {
                char c = (char)i;
                wr.Write(c);
            }
            wr.Write("\n");
            ///中文
            for (int i = 19968; i <= 40869; i++)
            {
                char c = (char)i;
                wr.Write(c);
            }
            ///其他
            wr.Write(@"、。·ˉˇ¨〃々—～‖…‘’“”〔〕〈〉《》「」『』〖〗【】±×÷∶∧∨∑∏∪∩∈∷√⊥∥∠⌒⊙∫∮≡≌≈∽∝≠≮≯≤≥∞∵
                    ∴♂♀°′″℃＄¤￠￡‰§№☆★○●◎◇◆□■△▲※→←↑↓〓ⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹ⒈⒉⒊⒋⒌⒍⒎⒏⒐⒑⒒⒓⒔⒕⒖⒗⒘⒙⒚⒛⑴⑵⑶⑷⑸⑹⑺⑻⑼⑽⑾
                    ⑿⒀⒁⒂⒃⒄⒅⒆⒇①②③④⑤⑥⑦⑧⑨⑩㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫ！＂＃￥％＆＇（）＊＋，－．／
                    ０１２３４５６７８９：；＜＝＞？＠ＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ［＼］＾＿｀ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏ
                    ｐｑｒｓｔｕｖｗｘｙｚ｛｜｝￣ぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのは
                    ばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎゐゑをんァアィイゥウェエォオカガキギク
                    グケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワ
                    ヰヱヲンヴヵヶΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρστυφχψω︵︶︹︺︿﹀︽︾﹁﹂﹃﹄︻︼︷︸︱︳︴
                    АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмн
                    опрстуфхцчшщъыьэюяāáǎàēéěèīíǐìōóǒòūúǔùǖǘǚǜüêɑńňㄅㄆㄇㄈㄉㄊㄋㄌㄍㄎㄏ
                    ㄐㄑㄒㄓㄔㄕㄖㄗㄘㄙㄚㄛㄜㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦㄧㄨㄩ─━│┃┄┅┆┇┈┉┊┋
                    ┌┍┎┏┐┑┒┓└┕┖┗┘┙┚┛├┝┞┟┠┡┢┣┤┥┦┧┨┩┪┫┬┭┮┯┰┱┲┳┴┵┶┷┸┹┺┻┼┽┾┿╀╁╂╃╄╅╆╇╈╉╊╋");
            wr.Close();
            f.Close();
        }

    }


    public class MyCharCode
    {

        /*GB2312
         * 0xA1A0 - 0xA9FF
         * 0xB0A0 - 0xBFFF
         * 0xC0A0 - 0xCFFF
         * 0xD0A0 - 0xDFFF
         * 0xE0A0 - 0xEFFF
         * 0xF0A0 - 0xF7FF
         */
        public static char[] GenGB2312()
        {
            System.Text.Encoding en = System.Text.Encoding.GetEncoding("GB2312");
            List<char> list = new List<char>(2000);

            HighLowBitEncodeFor(0xA1, 0xA9, 0xA0, 0xFF, en, list);
            HighLowBitEncodeFor(0xB0, 0xBF, 0xA0, 0xFF, en, list);
            HighLowBitEncodeFor(0xC0, 0xCF, 0xA0, 0xFF, en, list);
            HighLowBitEncodeFor(0xD0, 0xDF, 0xA0, 0xFF, en, list);
            HighLowBitEncodeFor(0xE0, 0xEF, 0xA0, 0xFF, en, list);
            HighLowBitEncodeFor(0xF0, 0xF7, 0xA0, 0xFF, en, list);

            return list.ToArray();
        }

        public static void HighLowBitEncodeFor(byte hMin, byte hMax, byte lMin, byte lMax, Encoding en, List<char> list)
        {
            byte[] bytebuffer = new byte[2];
            byte h;
            byte l;
            for (h = hMin; h <= hMax && h >= hMin; h++)
                for (l = lMin; l <= lMax && l >= lMin; l++)
                {
                    bytebuffer[0] = h;
                    bytebuffer[1] = l;
                    list.AddRange(en.GetChars(bytebuffer));
                }

        }
    }
}