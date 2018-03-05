using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSK1.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ComboBoxItem> ComboBoxItems { get; set; }
        ICrypter alghoritm;

        private int key0;
        private int key1;
        private string stringKey;

        public string StringKey
        {
            get { return stringKey; }
            set
            {
                stringKey = value;
                Debug.WriteLine(stringKey);
            }
        }

        public int Key0
        {
            get { return key0; }
            set
            {
                key0 = value;
                Debug.WriteLine(Key0);
            }
        }
        public int Key1
        {
            get { return key1; }
            set { key1 = value; }
        }





        public enum Alghoritm
        {
            Choose,
            RailFence,
            Matrix2a,
            Matrix2b,
            Matrix2c,
            Caesar,
            Vigenere
        }


        public MainWindow()
        {
            InitializeComponent();
            ComboBoxItems = new List<ComboBoxItem>();
            key0 = 3;
            key1 = 3;


            foreach (Alghoritm alg in Enum.GetValues(typeof(Alghoritm)))
                ComboBoxItems.Add(new ComboBoxItem() { Content = alg });
            DataContext = this;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var aa = ((ComboBox)sender).SelectedValue;
            SetAlghoritm((Alghoritm)((ComboBoxItem)aa).Content);
        }
        private void SetAlghoritm(Alghoritm alg)
        {
            KeyGrid.Children.Clear();
            switch (alg)
            {
                case Alghoritm.RailFence:
                    Key0 = 3;
                    var tb = new TextBox() { Width = 40, Text = "3" };
                    tb.TextChanged += new TextChangedEventHandler(Key0Update);
                    KeyGrid.Children.Add(new Label() { Content = "Fence height: " });
                    KeyGrid.Children.Add(tb);
                    break;
                case Alghoritm.Matrix2a:
                    StringKey = "3-1-4-2";
                    var tb2 = new TextBox() { Width = 150, Text = "3-1-4-2" };
                    tb2.TextChanged += new TextChangedEventHandler(StringKeyUpdate);
                    KeyGrid.Children.Add(new Label() { Content = "String Key: " });
                    KeyGrid.Children.Add(tb2);
                    break;
                case Alghoritm.Matrix2b:
                    StringKey = "CONVENIENCE";
                    var tb3 = new TextBox() { Width = 150, Text = "CONVENIENCE" };
                    tb3.TextChanged += new TextChangedEventHandler(StringKeyUpdate);
                    KeyGrid.Children.Add(new Label() { Content = "String Key: " });
                    KeyGrid.Children.Add(tb3);
                    break;
                case Alghoritm.Matrix2c:
                    StringKey = "CONVENIENCE";
                    var tb4 = new TextBox() { Width = 150, Text = "CONVENIENCE" };
                    tb4.TextChanged += new TextChangedEventHandler(StringKeyUpdate);
                    KeyGrid.Children.Add(new Label() { Content = "String Key: " });
                    KeyGrid.Children.Add(tb4);
                    break;
                case Alghoritm.Caesar:
                    Key0 = 5;
                    Key1 = 7;
                    var tb5 = new TextBox() { Width = 40, Text = "5" };
                    var tb6 = new TextBox() { Width = 40, Text = "7" };
                    tb5.TextChanged += new TextChangedEventHandler(Key0Update);
                    KeyGrid.Children.Add(new Label() { Content = "Key0: " });
                    KeyGrid.Children.Add(tb5);
                    KeyGrid.Children.Add(new Label() { Content = "Key1: " });
                    KeyGrid.Children.Add(tb6);
                    break;
                case Alghoritm.Vigenere:
                    StringKey = "BREAKBREAKBR";
                    var tb7 = new TextBox() { Width = 150, Text = "BREAKBREAKBR" };
                    tb7.TextChanged += new TextChangedEventHandler(StringKeyUpdate);
                    KeyGrid.Children.Add(new Label() { Content = "String Key: " });
                    KeyGrid.Children.Add(tb7);
                    break;
                default:
                    break;
            }
        }

        private void Encrypt0(object sender, RoutedEventArgs e)
        {
            var aa = algCB.SelectedValue;
            switch ((Alghoritm)((ComboBoxItem)aa).Content)
            {
                case Alghoritm.RailFence:
                    alghoritm = new RailFence(Key0);
                    break;
                case Alghoritm.Matrix2a:
                    alghoritm = new Matrix2a(StringKey);
                    break;
                case Alghoritm.Matrix2b:
                    alghoritm = new Matrix2b(StringKey);
                    break;
                case Alghoritm.Matrix2c:
                    alghoritm = new Matrix2c(StringKey);
                    break;
                case Alghoritm.Caesar:
                    alghoritm = new Caesar3b(Key0, Key1);
                    break;
                case Alghoritm.Vigenere:
                    alghoritm = new Vigenere(StringKey);
                    break;
                default:
                    break;
            }
            output0tb.Text = alghoritm.Encrypt(input0tb.Text);
        }

        private void Key0Update(object sender, RoutedEventArgs e)
        {
            int value = 0;
            if (int.TryParse(((TextBox)sender).Text, out value))
                Key0 = value;
        }
        private void Key1Update(object sender, RoutedEventArgs e)
        {
            int value = 0;
            if (int.TryParse(((TextBox)sender).Text, out value))
                Key1 = value;
        }

        private void StringKeyUpdate(object sender, RoutedEventArgs e)
        {
            StringKey = ((TextBox)sender).Text;
        }

        private void Decrypt1(object sender, RoutedEventArgs e)
        {
            var aa = algCB.SelectedValue;
            switch ((Alghoritm)((ComboBoxItem)aa).Content)
            {
                case Alghoritm.RailFence:
                    alghoritm = new RailFence(Key0);
                    break;
                case Alghoritm.Matrix2a:
                    alghoritm = new Matrix2a(StringKey);
                    break;
                case Alghoritm.Matrix2b:
                    alghoritm = new Matrix2b(StringKey);
                    break;
                case Alghoritm.Matrix2c:
                    alghoritm = new Matrix2c(StringKey);
                    break;
                case Alghoritm.Caesar:
                    alghoritm = new Caesar3b(Key0, Key1);
                    break;
                case Alghoritm.Vigenere:
                    alghoritm = new Vigenere(StringKey);
                    break;
                default:
                    break;
            }
            output1tb.Text = alghoritm.Decrypt(input1tb.Text);
        }
    }
}
