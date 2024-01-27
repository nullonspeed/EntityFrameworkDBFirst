using dataLayer;
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

namespace EntityFrameworkDBFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public NorthwindContext DB { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           DB = new NorthwindContext();
            try {
                int numofEmp = DB.Employees.Count();
                Title = $"{numofEmp} employees in Database";

                
                //Lieferanten + Company names + Sortiert nach dem alphabet

                cboSuppliers.ItemsSource = DB.Suppliers
                    .Select(x=>x)
                    .OrderBy(x=>x.CompanyName.ToUpper())
                    .ToList();
                





            } catch (Exception ex) { 
            Title= ex.Message;
            }
            
        }

        private void cboSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int? selSupp = ((Supplier)cboSuppliers.SelectedItem).SupplierId;
            if (selSupp != null)
            {
                lboProducts.ItemsSource = DB.Products.Where(x=>x.Supplier!=null && x.Supplier.SupplierId == selSupp).ToList();
            }
        }

        
        private void lboCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int? items = ((Product)lboProducts.SelectedItem)?.ProductId;
            if (items != null)
            {
                lboCustomers.ItemsSource = DB.OrderDetails.Where(x=> x.ProductId==items).Select(x=>x.Order.Customer).Distinct().ToList();
            }
        }
    }
}
