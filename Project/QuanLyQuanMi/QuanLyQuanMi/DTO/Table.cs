﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanMi.DTO
{
    public class Table
    {

        public bool IsPaid { get; set; }
        public Table(int id, string name)
        {
            this.ID = id;
            this.Name = name;
           
           
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            
          
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;
       

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        
    }
}
