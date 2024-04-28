﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Models.References.Contracts
{
    public interface ICanBeHashed
    {
        byte[] GetComputableSignature();
    }
}
