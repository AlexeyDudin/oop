using Lab4_2.Domain;
using Lab4_2.Interfaces;
using System;
using System.Collections.Generic;
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

namespace Lab4_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ICanvasDrawable> objects = new List<ICanvasDrawable>();
        private ICanvas myCanvas;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(List<ICanvasDrawable> objects)
        {
            InitializeComponent();
            this.objects = objects;
            myCanvas = new MyCanvas(canvasForm);
        }
    }
}
