﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;

namespace SmsManager.DataLayer.Entities
{
    [Table]
    public class Category
    {
        private int _id;
        private int _name;
        private byte[] _image;

        [Column(IsPrimaryKey = true)]
        public int Id{
            get { return _id; }
            set { _id = value; }
        }

        [Column]
        public int Name{
            get { return _name; }
            set { _name = value; }
        }

        [Column]
        public byte[] Image{
            get { return _image; }
            set { _image = value; }
        }
    }
}