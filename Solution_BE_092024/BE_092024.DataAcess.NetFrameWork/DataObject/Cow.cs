﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork.DataObject
{
    public class Cow : AnimalAbstract
    {
        public override string GetSound()
        {
            return "be be";
        }
    }
}