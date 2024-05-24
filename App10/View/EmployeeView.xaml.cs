using App10.View_Model;
using App10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace App10.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeView : ContentPage
    {
        //Sets a variable
        EmployeeViewModel _viewModel;
        bool _isUpdate;
        int employeeID;

        public EmployeeView()
        {
            InitializeComponent();
            //BindingContext = new EmployeeViewModel();
            _viewModel = new EmployeeViewModel();
            _isUpdate = false;   
        }

        public EmployeeView(EmployeeModel obj)
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();

            if (obj != null)
            {
                employeeID = obj.ID;
                employeeName.Text = obj.Name;
                employeeEmail.Text = obj.Email;
                employeeAddress .Text = obj.Address;
                _isUpdate |= true;
            }
        } 

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = employeeName.Text;
            obj.Email = employeeEmail.Text;
            obj.Address = employeeAddress.Text;

            //Checks if it is Update or Insert
            if (_isUpdate)
            {
                obj.ID = employeeID;
                await _viewModel.UpdateEmployee(obj); 
            }

            else
            {
                _viewModel.InsertEmployee(obj);
            }

            await Navigation.PopAsync();
        }

        //private async void Return(object sender, EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}

        //EmployeeModel obj = new EmployeeModel();
        //obj.Name = employeeName.Text;
        //    obj.Email = employeeEmail.Text;
        //    obj.Address = employeeAddress.Text;

        //    _viewModel.InsertEmployee(obj
    }
}