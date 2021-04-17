﻿using Idle.DataAccess.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idle.DataAccess.Fields
{
    [Table(TableNames.Languages)]
    public class Language : ModelBase, IDescriptive, IProgress, IXPCost, IXPIncome
    {
        public virtual string ImagePath { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Difficulty Difficulty { get; set; }

        public int XP { get; set; } = 0;
        public int Level { get; set; } = 1;
        public string Grade { get; set; } = "F";

        public virtual int XPCost { get; set; }
        public virtual int XPIncome {get; set;}

    }
}
