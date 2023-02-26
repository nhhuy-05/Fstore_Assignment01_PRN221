using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        IMemberResponsitory memberResponsitory;

        public MemberWindow(IMemberResponsitory mResponsitory)
        {
            InitializeComponent();

            memberResponsitory = mResponsitory;        
            GetMember();
        }

        public void GetMember()
        {
            lvMember.ItemsSource = memberResponsitory.GetMembers();
        }
    }
}
