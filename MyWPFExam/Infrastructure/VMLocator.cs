using BAL.Modules;
using MyWPFExam.ModelViews;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFExam.Infrastructure
{
    class VMLocator
    {
        IKernel kernel;
        public VMLocator()
        {
            kernel = new StandardKernel(new DIModule());
        }

        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
    }
}
