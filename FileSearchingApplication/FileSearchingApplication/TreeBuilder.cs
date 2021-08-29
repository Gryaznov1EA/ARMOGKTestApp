using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FastTreeNS;

namespace FileSearchingApplication
{
    //Класс для построения дерева файлов и каталогов.
    class TreeBuilder 
    {
        public delegate void UpdateNumberOfFiles (int[] numbersOfFiles);
        public delegate void UpdateCurrentCataloguePath (string currentCataloguePath);

        public event UpdateNumberOfFiles UpdatedNumberOfFiles; //Событие изменения количества просмотренных и найденных файлов.
        public event UpdateCurrentCataloguePath UpdatedCurrentCataloguePath; //Событие изменения текущего каталога поиска.

        public delegate void EndOfSearch();
        public event EndOfSearch endOfSearch; //Событие окончания поиска.


        private ManualResetEvent threadSuspendEvent; //Событие временной остановки поиска кнопкой "Пауза"

        public TreeBuilder() 
        {
            threadSuspendEvent = new ManualResetEvent(true);
        }

        //Свойство события временной остановки поиска кнопкой "Пауза"
        public bool ThreadSuspendEvent 
        {
            get 
            {
                return threadSuspendEvent.WaitOne(0);
            }
            set 
            {
                if (value == true)
                {
                    threadSuspendEvent.Set();
                }
                else 
                {
                    threadSuspendEvent.Reset();
                }
                
            }
        }

        //Построение дерева
        public void BuildTree(Node root, string fileMask) 
        {
            var FilesFound = 0;
            var FilesScanned = 0;
            try 
            {
                var toProcess = new Stack<Node>();
                toProcess.Push(root);

                while (toProcess.Count > 0)
                {
                    var node = toProcess.Pop();
                    try
                    {
                        UpdatedCurrentCataloguePath(node.FullPath);
                        foreach (var dir in Directory.GetDirectories(node.FullPath))
                        {
                            var n = new Node { FullPath = dir };
                            node.Add(n);
                            toProcess.Push(n);
                        }

                        foreach (var file in Directory.GetFiles(node.FullPath, "*.*")) 
                        {
                            FilesScanned++;
                        }


                        foreach (var file in Directory.GetFiles(node.FullPath, fileMask))
                        {
                            var n = new Node { FullPath = file, IsFile = true };
                            node.Add(n);
                            FilesFound++;
                        }
                        UpdatedNumberOfFiles.Invoke(new int[] { FilesFound, FilesScanned });

                        threadSuspendEvent.WaitOne();
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }

                endOfSearch();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }
    }
}
