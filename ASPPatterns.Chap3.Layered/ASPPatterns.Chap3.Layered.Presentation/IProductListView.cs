﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Service;

namespace ASPPatterns.Chap3.Layered.Presentation
{
    public interface IProductListView
    {
        void Display(IList<ProductViewModel> products);
        CustomerType CustomerType { get; }        
        string ErrorMessage { set; }
    }
}
