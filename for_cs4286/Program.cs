using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_cs4286
{
    class opt
    {
        InAppDictionary.BasicTrie trie;     // I 100% built this shxt here.
        string in_word = "ONEOHPENTAYIPEONEUTGSMAATHDOIOTGKILPTRWONHRFAILANIEATRDANHBATRDAETGHRFUTJILYTCCTFEATRDKHRFATRDUNWONEAETHACIHGHRFNIOTRDUNEONESBHFANTVEUHRFACMOUTHOTCHOONEIWAOESAYSHEDCELISEUENTVEIMSYNTOLISAIPEILMATSEIMOILCSETONTRDTGGILMATSELTORINMSSWATHDONEYTSBEROESONEWONTRKEDNHPPMYNLISONTOTGITLILCSETDONEUTGSMAATHDHAUNTOUEYNHELGWREEDBEBBESTRDVHREFTSCEAHDEATSEVESWFIIDHRDEEDRIUHLWIMSESETDWIWAOESADETSUEYTRCEFHROILEED";
        string dict_path = "C:\\Users\\tingk\\source\\repos\\EngVocabApp\\words_dictionary.txt";

        public opt() { }
        public void opt_find_words() {
            trie = new InAppDictionary.BasicTrie(dict_path);
            trie.setDefaultDictionaryTrie();
            for (int st = 0; st < in_word.Length; st++)
            {
                int pad = 1;
                while(trie.isValidWord(in_word.Substring(st, pad))) {
                    pad++;
                    if ((st + pad - 1) >= in_word.Length)
                    {
                        break;
                    }
                }
                if (st + pad - 1 <= in_word.Length)
                {
                    Console.Out.WriteLine("(" + st.ToString() + "," + (st + pad - 2).ToString() + "),");//  + " " + in_word.Substring(st, pad - 1));
                }
            }
        }
    }
    class Program
    {
        opt cur_opt;
        static void Main(string[] args)
        {
            opt cur_opt = new opt();
            cur_opt.opt_find_words();
            Console.ReadKey();
        }
    }
}
