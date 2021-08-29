using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearchingApplication
{
    public partial class Form1 : Form
    {
        TreeBuilder _treeBuilder;
        Thread searchThread;

        Node root = null;

        private DateTime _timerStartTime; //Для сохранения времени начала поиска для вычисления прошедшего времени.

        public delegate void UpdateNumbers(int[] arrayNumbers); // Для обновления отображения текущего количества просмотренных и найденных файлов.
        public delegate void UpdateCurrentPath(string currentCataloguePath); //Для обновления отображения текущего каталога в процессе поиска.

        SearchParametersForJSON searchParametersForJSON = new SearchParametersForJSON(); //Переменная для сохранения параметров поиска в json.

        string pathToSaveFile = AppDomain.CurrentDomain.BaseDirectory + "parameters.json"; //Переменная с путём до файла.

        public Form1()
        {
            InitializeComponent();

            //Дефолтные параметры поиска
            textBoxCatalogue.Text = "C:/";
            textBoxMask.Text = "*.*";


            //Загрузка сохранённых параметров поиска из файла (если файл был ранее создан).
            if (File.Exists(pathToSaveFile)) 
            {
                searchParametersForJSON = JsonConvert.DeserializeObject<SearchParametersForJSON>(File.ReadAllText(pathToSaveFile));
                textBoxCatalogue.Text = searchParametersForJSON.RootPath;
                textBoxMask.Text = searchParametersForJSON.FilenameMask;
            }



            _treeBuilder = new TreeBuilder();

            _treeBuilder.UpdatedNumberOfFiles += UpdateNumberOfFiles; //Обновление отображения текущего количества просмотренных и найденных файлов.
            _treeBuilder.UpdatedCurrentCataloguePath += UpdateCurrentCataloguePath; //Обновление отображения текущего каталога в процессе поиска.
            _treeBuilder.endOfSearch += OnCompletedSearch; //Обновление состояния кнопок и полей ввода при завершении поиска.

            //Настройка начального состояния кнопок.
            buttonPauseSearch.Enabled = false;
            buttonContinueSearch.Enabled = false;
            
            //Создание нового файла для сохранения параметров (если ещё не создан) и сохранение параметров в этот файл.
            searchParametersForJSON.RootPath = textBoxCatalogue.Text;
            searchParametersForJSON.FilenameMask = textBoxMask.Text;
            File.WriteAllText(pathToSaveFile, JsonConvert.SerializeObject(searchParametersForJSON));
        }

        //Кнопка "Пауза".
        private void buttonPauseSearch_Click(object sender, EventArgs e)
        {
            //Изменение состояния кнопок и полей ввода.
            buttonStartSearching.Enabled = true;
            buttonContinueSearch.Enabled = true;
            buttonRootChoose.Enabled = true;
            textBoxCatalogue.Enabled = true;
            textBoxMask.Enabled = true;
            buttonPauseSearch.Enabled = false;
            timer1.Enabled = false;

            //Остановка поиска.
            try 
            {
                _treeBuilder.ThreadSuspendEvent = false;
            }
            catch (Exception exc) 
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
            
        }

        //Кнопка "Продолжить"
        private void buttonContinueSearch_Click(object sender, EventArgs e)
        {
            //Изменение состояния кнопок и полей ввода.
            buttonStartSearching.Enabled = false;
            buttonContinueSearch.Enabled = false;
            buttonRootChoose.Enabled = false;
            textBoxCatalogue.Enabled = false;
            textBoxMask.Enabled = false;
            buttonPauseSearch.Enabled = true;
            timer1.Enabled = true;

            //Возобновление поиска.
            try
            {
                _treeBuilder.ThreadSuspendEvent = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        //Кнопка "Выбрать" для выбора каталога, в котором будет производиться поиск.
        private void buttonRootChoose_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (FolderBrowserDialog folderBrowseDialog = new FolderBrowserDialog())
            {
                if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = folderBrowseDialog.SelectedPath;
                }
            }
            textBoxCatalogue.Text = filePath;
        }

        //Кнопка "Поиск", по нажатию которой начинается новый поиск файлов по указанной маске.
        private void buttonStartSearching_Click(object sender, EventArgs e)
        {
            root = null;
            root = new Node(textBoxCatalogue.Text);
            var fileMask = textBoxMask.Text;
            Application.Idle -= BuildTree;

            //Запуск таймера.
            _timerStartTime = DateTime.Now;
            timer1.Enabled = true;

            //Изменение состояния кнопок и полей ввода.
            buttonStartSearching.Enabled = false;
            buttonContinueSearch.Enabled = false;
            buttonRootChoose.Enabled = false;
            textBoxCatalogue.Enabled = false;
            textBoxMask.Enabled = false;
            buttonPauseSearch.Enabled = true;

            //Обновление состояния дерева для нового поиска.
            if (searchThread != null) 
            {
                _treeBuilder.ThreadSuspendEvent = false;
                _treeBuilder.UpdatedNumberOfFiles -= UpdateNumberOfFiles;
                _treeBuilder.UpdatedCurrentCataloguePath -= UpdateCurrentCataloguePath;
                _treeBuilder.endOfSearch -= OnCompletedSearch;
                _treeBuilder = null;
                _treeBuilder = new TreeBuilder();
                _treeBuilder.UpdatedNumberOfFiles += UpdateNumberOfFiles;
                _treeBuilder.UpdatedCurrentCataloguePath += UpdateCurrentCataloguePath;
                _treeBuilder.endOfSearch += OnCompletedSearch;
                searchThread = null;
            }


            //Запуск поиска.
            searchThread = new Thread(() => _treeBuilder.BuildTree(root, fileMask))
            {
                IsBackground = true
            };
            searchThread.Start();

            Application.Idle += new EventHandler(BuildTree);
            
            try
            {

            }
            catch (Exception exc) 
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        //Построение дерева, отображаемого на форме.
        private void BuildTree(object sender, System.EventArgs e)
        {
            if (searchThread.IsAlive)
            {
                fastTree1.Build(root);
            }
        }


        //Для изменения свойств элементов формы.
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        
        //Изменение свойств элементов формы.
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    System.Reflection.BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        //Обновление отображения текущего количества просмотренных и найденных файлов.
        private void UpdateNumberOfFiles(int[] numbersArray) 
        {
            try 
            {
                SetControlPropertyThreadSafe(labelNumberOfFilesFound, "Text", numbersArray[0].ToString());
                SetControlPropertyThreadSafe(labelNumberOfScannedFiles, "Text", numbersArray[1].ToString());
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        //Обновление отображения текущего каталога в процессе поиска.
        private void UpdateCurrentCataloguePath(string currentCataloguePath) 
        {
            try
            {
                SetControlPropertyThreadSafe(labelCurrentScannedCataloguePath, "Text", currentCataloguePath);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        //Обновление состояния кнопок, полей ввода и таймера при завершении поиска.
        private void OnCompletedSearch()
        {
            try
            {
                SetControlPropertyThreadSafe(buttonStartSearching, "Enabled", true);
                SetControlPropertyThreadSafe(buttonContinueSearch, "Enabled", false);
                SetControlPropertyThreadSafe(buttonRootChoose, "Enabled", true);
                SetControlPropertyThreadSafe(textBoxCatalogue, "Enabled", true);
                SetControlPropertyThreadSafe(textBoxMask, "Enabled", true);
                SetControlPropertyThreadSafe(buttonPauseSearch, "Enabled", false);
                timer1.Enabled = false;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                System.Diagnostics.Debug.WriteLine(exc.ToString());
            }
        }

        //Вычисление и отображение времени, прошедшего от начала поиска.
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan passedTime = DateTime.Now - _timerStartTime;
            labelSearchTimeNumber.Text = passedTime.ToString("hh\\:mm\\:ss");
        }

        //Запись пути к каталогу поиска в переменную для сохранения параметров в файл при изменении.
        private void textBoxCatalogue_TextChanged(object sender, EventArgs e)
        {
            searchParametersForJSON.RootPath = textBoxCatalogue.Text;
        }

        //Запись маски поиска файлов к каталогу поиска в переменную для сохранения параметров в файл при изменении.
        private void textBoxMask_TextChanged(object sender, EventArgs e)
        {
            searchParametersForJSON.FilenameMask = textBoxMask.Text;
        }

        //Сохранение параметров поиска в файл при закрытии формы.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(pathToSaveFile, JsonConvert.SerializeObject(searchParametersForJSON));
        }
    }
}
