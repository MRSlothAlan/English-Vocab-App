using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class implements the basic trie structure.
 * */

namespace InAppDictionary
{
    public class Node : IComparable<Node>
    {
        public char c { get; set; }
        public List<Node> child { get; set; }
        public Node parent { get; set; }

        public Node() {
            this.c = '#';
            child = new List<Node>();
            parent = null;
        }
        public Node(char in_char)
        {
            this.c = in_char;
            child = new List<Node>();
            parent = null;
        }
        public int CompareTo(Node inN)
        {
            return this.c.CompareTo(inN.c);
        }
    }
    public class BasicTrie
    {
        private Node root { get; set; }
        private FileOperations fileOpt { get; set; }
        private string cw { get; set; }  // current word;
        private bool wordFound;
        private List<string> wordSuggestions;
        private int MAX_SUGGEST = 30;
        private int MAX_SUGGEST_SEARCH_DEPTH = 15;  

        public BasicTrie(string in_default_dict_path)
        {
            this.root = new Node('@');  // @ is only used for the root.
            this.fileOpt = new FileOperations(in_default_dict_path);
        }

        private void traverseSimilarWords(int curDepth, Node curN)
        {
            if (this.wordSuggestions.Count >= MAX_SUGGEST) { return; }
            if (this.binarySearchChar('#', curN) > -1)
            {
                // starting from this node, traverse back to parent and load the suggestion
                Node t = curN;
                string wordSugg = "";
                while (!curN.Equals(this.root))
                {
                    wordSugg += curN.c;
                    curN = curN.parent;
                }
                string rw = "";
                for (int i = wordSugg.Length - 1; i >= 0; i--) { rw += wordSugg[i]; }
                this.wordSuggestions.Add(rw);
                return;
            }
            if (curDepth >= MAX_SUGGEST_SEARCH_DEPTH) { return; }
            for (int i = 0; i < curN.child.Count; i++)
            {
                if (!curN.child[i].c.Equals('#'))
                {
                    this.traverseSimilarWords(curDepth + 1, curN.child[i]);
                }
            }
            
        }

        public List<string> findSimilarWords(string in_str)
        {
            /*
             * traverse the trie find similar words.
             * */

            this.wordSuggestions = new List<string>();
            this.wordSuggestions.Clear();
            Node curN = this.root;
            int idx = 0;
            while (idx < in_str.Length)
            {
                int childIdx = this.binarySearchChar(in_str[idx], curN);
                if (childIdx != -1)
                {
                    curN = curN.child[childIdx];
                    idx++;
                }
                else
                {
                    break;
                }
            }
            if (idx >= in_str.Length) {
                this.traverseSimilarWords(0, curN);
            }

            return this.wordSuggestions;
        }

        public bool isValidWord(string in_str)
        {
            /*
             * Check whether a word existed in the dictionary in log N time.
             * */
            this.wordFound = false; // initialize as false
            this.cw = in_str.ToLower();
            this.searchTrie(0, this.root);
            return this.wordFound;
        }

        private void searchTrie(int cwIdx, Node curN)
        {
            if (this.wordFound) { return; }
            if (cwIdx >= this.cw.Length && 
                this.binarySearchChar('#', curN) > -1) { this.wordFound = true; return; }
            if (cwIdx >= this.cw.Length) { return; }
            curN.child.Sort();
            int childIdx = this.binarySearchChar(this.cw[cwIdx], curN);
            if (childIdx > -1)
            {
                searchTrie(cwIdx + 1, curN.child[childIdx]);
            }
            return;
        }

        private int binarySearchChar(char cwChar, Node curN)
        {
            int len = curN.child.Count;
            int l = 0, r = len - 1;
            while (l < r)
            {
                int mid = (l + r) / 2;
                if (curN.child[mid].c.Equals(cwChar))
                {
                    return mid;
                }
                else if (curN.child[mid].c < cwChar)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            if (l == r && curN.child[l].c == cwChar)
            {
                return l;
            }
            return -1;
        }
        
        private int insertChildInOrder(char cwChar, Node curN)
        {
            curN.child.Insert(0, new Node(cwChar)); // have the reconfirm its behaviours
            curN.child.Sort();
            return this.binarySearchChar(cwChar, curN);
        }

        private void setParent(Node curN)
        {
            for (int i = 0; i < curN.child.Count; i++)
            {
                curN.child[i].parent = curN;
            }
        }

        private void setTrieParents(Node curN)
        {
            if (curN.child.Count == 0) { return; }
            this.setParent(curN);
            for (int i = 0; i < curN.child.Count; i++)
            {
                setTrieParents(curN.child[i]);
            }
        }

        private void insertTrie(int cw_idx, Node curN)
        {
            if (cw_idx >= cw.Length)
            {
                int endIdx = this.binarySearchChar('#', curN);
                if (endIdx == -1)
                {
                    this.insertChildInOrder('#', curN);
                }
                return;
            }
            char cwChar = cw[cw_idx];
            int len = curN.child.Count;

            int nIdx = this.binarySearchChar(cwChar, curN);
            if (nIdx > -1) { insertTrie(cw_idx + 1, curN.child[nIdx]); return; }
            insertTrie(cw_idx + 1, curN.child[this.insertChildInOrder(cwChar, curN)]);
            return;
        }

        private void exportTrie()
        {
            /*
             * Export the word tree to a format. something like python pickle.
             * */
        }

        private void LoadTrie()
        {
            foreach (string in_str in this.fileOpt.in_text)
            {
                this.cw = in_str;
                this.insertTrie(0, this.root); 
            }
            this.setTrieParents(this.root);
        }

        public void setCustomizedTrie(string in_custom_txt_path)
        {
            
        }
        public void setDefaultDictionaryTrie()
        {
            this.fileOpt.readDictionary(FileOperations.defaultPath);
            this.LoadTrie();
        }
        public void setDefaultDictionaryTrie(string in_dict_path)
        {
            this.fileOpt.readDictionary(in_dict_path);
            this.LoadTrie();
        }
    }
}
