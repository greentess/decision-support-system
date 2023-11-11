using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using System.Diagnostics;
using ClosedXML.Excel;
using System.Collections.ObjectModel;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window11.xaml
    /// </summary>
    public class Reklama
    {

        public Reklama()
        {
        }

        public int num { get; set; }
        public string name { get; set; }
        public int w { get; set; }
        public int p { get; set; }

        public Reklama(int Num, string Name, int Weight, int P)
        {
            num = Num;
            name = Name;
            w = Weight;
            p = P;
        }

        public static int maxx_PP;
        public static int maxx_nn;
        
    }


    class Backpack
    {
        bool content { get; set; } //в рюкзаке есть что-то или нет
        public List<Reklama> reklama_list { get; set; } //список предметов в рюкзаке
        public int maxP; //максимальная ценность рюкзака
        public static int My_w;
        public static int My_p;
        public int max
        {
            get { return maxP; }
            set { maxP = value; }
        }

        public Backpack()
        {
            content = false; //в рюкзаках ничего не лежит
            reklama_list = new List<Reklama>();
            maxP = 0; //изначально все рюкзаки пустые
        }
        public static Backpack Max(Backpack[] b) //ищем рюкзак с максимальной суммарной ценностью
        {
            Backpack res = b[0];
            for (int i = 0; i < b.Length; i++)
            {
                if (res.maxP < b[i].maxP)
                    res = b[i];
            }
            return res;
        }

        
        public static Backpack Fill(Reklama[] a, Backpack[] bp, int max)
        {
            bp[0].content = true; //нулевой рюкзак считаем заполненным
            for (int i = 0; i < a.Length; i++) //цикл по всем предметам
            {
                for (int j = max; j >= a[i].w; j--) //цикл начиная с последнего рюкзака с максимальным весом 
                                                    //до минимального рюкзака в который можем положить i предмет
                {
                    int k = j - a[i].w; // вычитаем вес предмета
                    if (bp[k].content == true) //если в полученном рюкзаке уже что-то лежит, то сравниваем ценность
                    {
                        if (bp[k].maxP + a[i].p >= bp[j].maxP) //если ценность с новым предметом больше с ценностью уже положенных
                        {
                            bp[j].maxP = bp[k].maxP + a[i].p; //меняем ценность
                            bp[j].reklama_list.Clear(); //очищаем предметы в рюкзаке
                            foreach (var p in bp[k].reklama_list) //добавляем все из рюкзака к и добавляем еще i предмет
                            {
                                bp[j].reklama_list.Add(p);
                            }
                            bp[j].reklama_list.Add(a[i]);
                            bp[j].content = true;
                        }
                    }
                }
            }
            My_w = 0;
            My_p = 0;
            Backpack res = Backpack.Max(bp); //выбираем рюкзак с наибольшей ценностью
            foreach (var p in res.reklama_list)
            {
                My_w += p.w;
                My_p += p.p;
            }
            return res;
        }
    }


    public partial class Window11
    {
        public Window11()
        {
            InitializeComponent();
            DataContext = this;
            GridCollection = new ObservableCollection<Reklama>();

        }

        public ObservableCollection<Reklama> GridCollection { get; set; }
        public static IEnumerable<Reklama> fromExcel()
        {
            MessageBox.Show("В ячейке A2 необходимо указать общий бюджет. Далее, начиная со строки А[5], заполнять поочередно в ячейках информацию о каждой рекламе. В столбце А[1] указать номер варианта рекламы, в столбце А[2] - наименование, в столбце А[3] - стоимость покупки в тыс.руб. и в столбце А[4] - средние охваты (чел.)."
                            , "Требования к структуре файла");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xcel Files(.xls)|*.xls| xcel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            Nullable<bool> result = openFileDialog1.ShowDialog();
            Microsoft.Office.Interop.Excel.Application ExcelApp;
            Workbook excelappworkbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            Range excelcells, excelcells1, excelcells2, excelcells3, excelcells4;

            if (result == true)
            {

                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                excelappworkbook = ExcelApp.Workbooks.Open(openFileDialog1.FileName);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelappworkbook.Sheets[1];
                excelcells = worksheet.Cells[2, 1];
                Reklama.maxx_PP = Convert.ToInt32(excelcells.Value);
                excelcells = worksheet.Cells[2, 2];
                Reklama.maxx_nn = Convert.ToInt32(excelcells.Value);

                //maxx_PP = worksheet.Cell(2, 1).GetValue<int>();
                //maxx_PP = worksheet.Cell(2, 1).GetValue<int>();

                {
                    // Перебираем диапазон нужных строк
                    for (int row = 5; row < 5 + Reklama.maxx_nn; ++row)
                    {
                        excelcells1 = worksheet.Cells[row, 1];
                        excelcells2 = worksheet.Cells[row, 2];
                        excelcells3 = worksheet.Cells[row, 3];
                        excelcells4 = worksheet.Cells[row, 4];
                        // По каждой строке формируем объект
                        Reklama reklama_i = new Reklama
                        {

                            num = Convert.ToInt32(excelcells1.Value),
                            name = Convert.ToString(excelcells2.Value),
                            w = Convert.ToInt32(excelcells3.Value),
                            p = Convert.ToInt32(excelcells4.Value),
                        };
                        // И возвращаем его
                        //workbook.Close();
                        yield return reklama_i;
                    }
                }

                ExcelApp.Quit();
            }
        }

        private void dowload_Button_Click(object sender, RoutedEventArgs e)
        {
            var reklama_list = fromExcel().ToList();
            var ok_reklama_list = reklama_list.Where(x => x.w <= Reklama.maxx_PP).ToList();
            var non_reklama_list = reklama_list.Where(x => x.w > Reklama.maxx_PP).ToList();
            reklama_listDataGrid.ItemsSource = ok_reklama_list;
            NONreklama_listDataGrid.ItemsSource = non_reklama_list;
            max.Text = Reklama.maxx_PP.ToString();
            tab1.Visibility = Visibility.Visible;
            if (non_reklama_list.Count!=0)
            tab2.Visibility = Visibility.Visible;
        }





        private void calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {  
                Reklama[] reklama_list = reklama_listDataGrid.ItemsSource.Cast<Reklama>().ToArray();
                int MaxW = Convert.ToInt32(max.Text);

                Backpack[] backpacks = new Backpack[MaxW + 1];
                for (int i = 0; i < backpacks.Length; i++)
                {
                    backpacks[i] = new Backpack();
                }
                var res = Backpack.Fill(reklama_list, backpacks, MaxW);

                var optimized_reklama_list = res.reklama_list;
                optimized_reklama_listDataGrid.ItemsSource = optimized_reklama_list;
                OptMax.Text = Backpack.My_w.ToString();
                OptPP.Text = Backpack.My_p.ToString();
                System.Windows.Application.Current.MainWindow = this;
                System.Windows.Application.Current.MainWindow.Width = 1176;
                
                if (!(MaxW > 0))
                {
                    MessageBox.Show("Недопустимое значение указанного бюджета!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Недопустимые данные!");
                return;
            }
           
        }
        


        //очистить
        private void delete_Button_Click(object sender, RoutedEventArgs e)
        {
            //делаем кнопку "Сохранить в файл" невидимой
            save.Visibility = Visibility.Hidden;
            tab1.Visibility = Visibility.Hidden;
            tab2.Visibility = Visibility.Hidden;

            max.Text = "";
            reklama_listDataGrid.ItemsSource = null;
            reklama_listDataGrid.Items.Refresh();
            NONreklama_listDataGrid.ItemsSource = null;
            NONreklama_listDataGrid.Items.Refresh();

            OptMax.Text = "";
            OptPP.Text = "";
            optimized_reklama_listDataGrid.ItemsSource = null;
            optimized_reklama_listDataGrid.Items.Refresh();

            Reklama[] del_event = new Reklama[] { new Reklama()};


            //GridCollection = new ObservableCollection<Reklama>();
            reklama_listDataGrid.Items.Add(del_event);

            reklama_listDataGrid.Items.Refresh();
        }
        private void info_Button_Click(object sender, RoutedEventArgs e)
        {
           
            win2 win22 = new win2();
            win22.Show();
        }

        private void exit_Button_Click(object sender, RoutedEventArgs e)
        {
                MainWindow win1 = new MainWindow();
                this.Close();
                win1.Show();
        }


        //сохранить в файл exel
        private void save_Button_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "xcel Files(.xls)|*.xls| xcel Files(.xlsx)| *.xlsx | Excel Files(*.xlsm) | *.xlsm";
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                app.WindowState = XlWindowState.xlMaximized;

                Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = wb.Worksheets[1];
                Range excelcells;
                
                DateTime currentDate = DateTime.Now;

                Range _excelCells0 = ws.get_Range("A1", "D1").Cells;
                _excelCells0.Merge(Type.Missing);
                ws.Range["A1"].Value = "ОТЧЕТ";
                excelcells = ws.Range["A1"];
                excelcells.Font.Bold = true;
                ws.get_Range("A1", "D1").Style.HorizontalAlignment = XlHAlign.xlHAlignCenter; 

                Range _excelCells2 = ws.get_Range("A3", "D3").Cells;
                _excelCells2.Merge(Type.Missing);
                ws.Range["A3"].Value = "Общий бюджет: "+ max.Text;
                ws.get_Range("A3", "D3").Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;


                Range _excelCells1 = ws.get_Range("A5", "B5").Cells;
                _excelCells1.Merge(Type.Missing);
                ws.Range["A5"].Value = "ИСХОДНЫЙ НАБОР РЕКЛАМЫ:";
                _excelCells1.Columns.AutoFit();






                
                excelcells = ws.Range["A7"];
                excelcells.Value = "№";
                excelcells.Font.Bold = true;
                excelcells.Columns.AutoFit();


                excelcells = ws.Range["B7"];
                excelcells.Value = "Наименование";
                excelcells.Font.Bold = true;
                

                excelcells = ws.Range["C7"];
                excelcells.Value = "Стоимость (тыс.руб.)";
                excelcells.Font.Bold = true;
                excelcells.Columns.AutoFit();

                excelcells = ws.Range["D7"];
                excelcells.Value = "Охваты (чел.)";
                excelcells.Font.Bold = true;
                excelcells.Columns.AutoFit();


                int k = 0;
                int indStr = 8;
                int indStlb = 1;
                foreach (Reklama f in reklama_listDataGrid.ItemsSource)
                {
                    ws.Cells[indStr, indStlb] = f.num.ToString();
                    ws.Cells[indStr, indStlb+1] = f.name.ToString();
                    ws.Cells[indStr, indStlb+2] = f.w.ToString();
                    ws.Cells[indStr, indStlb+3] = f.p.ToString();
                    indStr++;
                    k++;
                }


                indStr++;
                indStlb = 2;

                Range _excelCellss = ws.get_Range("A"+ indStr, "B"+ indStr).Cells;
                _excelCellss.Merge(Type.Missing);
                ws.Range["A" + indStr].Value = "ОПТИМАЛЬНЫЙ НАБОР РЕКЛАМЫ:";
                _excelCellss.Columns.AutoFit();
                indStr++;

                excelcells = ws.Range["A" + indStr];
                excelcells.Value = "№";
                excelcells.Font.Bold = true;
                


                excelcells = ws.Range["B" + indStr];
                excelcells.Value = "Наименование";
                excelcells.Font.Bold = true;
                

                excelcells = ws.Range["C" + indStr];
                excelcells.Value = "Стоимость (тыс.руб.)";
                excelcells.Font.Bold = true;
                

                excelcells = ws.Range["D" + indStr];
                excelcells.Value = "Охваты (чел.)";
                excelcells.Font.Bold = true;
               
                indStr++;
                indStlb = 1;


                foreach (Reklama f in optimized_reklama_listDataGrid.ItemsSource)
                {
                    ws.Cells[indStr, indStlb] = f.num.ToString();
                    ws.Cells[indStr, indStlb + 1] = f.name.ToString();
                    ws.Cells[indStr, indStlb + 2] = f.w.ToString();
                    ws.Cells[indStr, indStlb + 3] = f.p.ToString();
                    indStr++;
                }

                indStr = indStr + 1;

                Range _excelCells22 = ws.get_Range("A"+ indStr, "B" + indStr).Cells;
                _excelCells22.Merge(Type.Missing);
                ws.Range["A" + indStr].Value = "Затраты бюджета (тыс.руб.): " + OptMax.Text;

                //ws.Cells[indStr, 1] = "Затраты бюджета: " + OptMax.Text;

                Range _excelCells11 = ws.get_Range("C" + indStr, "D" + indStr).Cells;
                _excelCells11.Merge(Type.Missing);
                ws.Range["C" + indStr].Value = "Наибольшие охваты (чел.): " + OptPP.Text;

                indStr = indStr + 2;

                Range _excelCells222 = ws.get_Range("A" + indStr, "B" + indStr).Cells;
                _excelCells222.Merge(Type.Missing);
                ws.Range["A" + indStr].Value = "Дата: " + DateTime.Now.ToString("dd MMMM yyyy");
                indStr = indStr + 1;

                //ws.Cells[indStr+1, 1] = "Дата:";
                //ws.Cells[indStr+1, 2] = DateTime.Now.ToString("dd MMMM yyyy");

                Range _excelCells2222 = ws.get_Range("A" + indStr, "B" + indStr ).Cells;
                _excelCells2222.Merge(Type.Missing);
                ws.Range["A" + indStr ].Value = "Подпись:______________";

                //ws.Cells[indStr+1, 5] = "Подпись";
                //ws.Cells[indStr+1, 6] = "______________";
                ws.Columns[2].ColumnWidth = 46;
                app.Quit();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
