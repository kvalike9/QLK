﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK.DTO
{
    public class Unit
    {
        private int _ID;
        private string _DisplayName;

        public Unit(DataRow row)
        {
            this.ID = int.Parse(row["Id"].ToString());
            this.DisplayName = row["DisplayName"].ToString();
        }
        public Unit(int id, string name)
        {
            this.ID = id;
            this.DisplayName = name;
        }

        public int ID { get => _ID; set => _ID = value; }
        public string DisplayName { get => _DisplayName; set => _DisplayName = value; }
    }
}
