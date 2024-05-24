using App10.Model;
using App10.View_Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeePage : ContentPage
    {

        EmployeeViewModel viewModel;


        public ShowEmployeePage()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
        }

        private void showEmployeePage()
        {
            var res = viewModel.GetAllEmployees().Result;
            lstData.ItemsSource = res;  
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showEmployeePage();
        }

        private async void AddEmployee(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeView());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                EmployeeModel obj = (EmployeeModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new EmployeeView(obj));
                            break;

                    case "Delete":
                        viewModel.DeleteEmployee(obj);
                        showEmployeePage();
                            break;
                }

                lstData.SelectedItem = null;
            }
        }
    }
}