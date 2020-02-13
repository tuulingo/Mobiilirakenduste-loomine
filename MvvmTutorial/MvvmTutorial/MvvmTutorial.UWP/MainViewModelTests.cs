using MvvmTutorial.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MvvmTutorial.UWP
{
    public class MainViewModelTests
    {
        [Fact]
        public void Recalculate_SubTotal100_Total120()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.SubTotal = 100;
            mainViewModel.Generosity = 0.2;
            Assert.Equal(120, mainViewModel.Total);
        }
    }
}
