﻿using MedicalInstitutionApp.ViewModel;
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
using System.Windows.Shapes;

namespace MedicalInstitutionApp.View
{
    /// <summary>
    /// Interaction logic for ManagerPannelView.xaml
    /// </summary>
    public partial class ManagerPannelView : Window
    {
        public ManagerPannelView()
        {
            DataContext = new ManagerPannelViewModel(this);
            InitializeComponent();
        }
    }
}
