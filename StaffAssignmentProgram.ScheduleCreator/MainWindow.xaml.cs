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

namespace SAP.ScheduleCreator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainWindowViewModel vm;
		public MainWindow()
		{
			vm = new MainWindowViewModel();
			DataContext = vm;
			InitializeComponent();
			//StaffSearchType.SelectedIndex = 0;
		}

		private void StaffMainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//vm.StaffEditExisting.RaiseCanExecuteChanged();
			//vm.StaffDeleteSelected.RaiseCanExecuteChanged();
		}

		private void StaffMainList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			//vm.StaffEditExisting.Execute(StaffAllList.SelectedItem);
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//ComboBox b = sender as ComboBox;
			//b.DataContext = e.AddedItems.ToString();

			//for (int i = 0; i < vm.MondayNightOff.StaffMemberNames.Count; i++)
			//{
			//	var x = vm.MondayNightOff.StaffMemberNames.ElementAt(i);
			//	x = e.AddedItems.ToString();
			//}
		}

		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
