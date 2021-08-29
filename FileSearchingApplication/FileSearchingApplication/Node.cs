using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchingApplication
{
    //Элемент дерева
    public class Node : IEnumerable<Node>
    {
        private List<Node> nodes;
        //Флаг для отметки, что элемент является файлом.
        public bool IsFile { get; set; }
        //Полный путь
        public string FullPath { get; set; }
        //Имя
        public string Name { get { return Path.GetFileName(FullPath); } }

        //Наличие файлов в каталоге (если каталог) или в подкаталогах (если есть).
        public bool HasFile
        {
            get
            {
                return IsFile || Nodes.Any(n => n.HasFile);
            }
        }

        public Node()
        {
            nodes = new List<Node>();
        }

        public Node(string rootPath) 
        {
            nodes = new List<Node>();
            FullPath = rootPath;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? FullPath : Name;
        }

        //Добавление элемента в список элементов.
        public void Add(Node node)
        {
            nodes.Add(node);
        }

        IEnumerable<Node> Nodes
        {
            get
            {
                for (int i = 0; i < nodes.Count; i++)
                    yield return nodes[i];
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return Nodes.Where(n => n.HasFile).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
