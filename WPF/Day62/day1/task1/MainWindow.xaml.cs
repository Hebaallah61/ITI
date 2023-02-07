using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace task1
{
    /// <summary>
    /// Interaction logic for Paint.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Change_Color(object sender, RoutedEventArgs e)
        {

            switch (((RadioButton)sender).Content.ToString())
            {
                case "Red":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "Green":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "Blue":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Magenta":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
            }
        }

        private void Change_Mode(object sender, RoutedEventArgs e)
        {

            switch (((RadioButton)sender).Content.ToString())
            {
                case "Ink":

                    InkCan.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Select":

                    InkCan.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case "Erase":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;

                case "Erase by strock":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void Change_shape(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Ellipse":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;

                case "Rectangle":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;

                    break;
            }
        }

        private void Change_size(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Small":

                    InkCan.DefaultDrawingAttributes.Width = 3;
                    InkCan.DefaultDrawingAttributes.Height = 3;
                    break;

                case "Normal":

                    InkCan.DefaultDrawingAttributes.Width = 6;
                    InkCan.DefaultDrawingAttributes.Height = 6;

                    break;
                case "Large":

                    InkCan.DefaultDrawingAttributes.Width = 10;
                    InkCan.DefaultDrawingAttributes.Height = 10;

                    break;
            }
        }

        private void New_(object sender, RoutedEventArgs e)
        {
            InkCan.Strokes.Clear();
        }
        private void Save_(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                InkCan.Strokes.Save(fs);
                fs.Close();
            }
        }
        private void Load_(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (openFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName,
                                               FileMode.Open);
                InkCan.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
            
        }
        private void Cut_(object sender, RoutedEventArgs e)
        {
            if(this.InkCan.GetSelectedStrokes().Count>0) { this.InkCan.CutSelection(); }
        }
        private void Past_(object sender, RoutedEventArgs e)
        {
            if(this.InkCan.CanPaste()) this.InkCan.Paste();

        }
        private void Copy_(object sender, RoutedEventArgs e)
        {
            if(this.InkCan.GetSelectedStrokes().Count>0) { this.InkCan.CopySelection(); }

        }
    }
}
