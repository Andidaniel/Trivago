﻿using System;
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
using Trivago.Data;

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for NoAccountView.xaml
    /// </summary>
    public partial class NoAccountView : Window
    {
        private readonly HotelContext _hotelContext;
        public NoAccountView(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
            InitializeComponent();
        }
    }
}