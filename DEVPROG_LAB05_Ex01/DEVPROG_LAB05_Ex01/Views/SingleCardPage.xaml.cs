using DEVPROG_LAB05_Ex01.Models;
using DEVPROG_LAB05_Ex01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DEVPROG_LAB05_Ex01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleCardPage : ContentPage
    {
        TrelloCard gCard;
        public SingleCardPage(TrelloCard card)
        {
            InitializeComponent();
            gCard = card;
            ShowCard();
        }

        private void ShowCard()
        {
          
        }
    }
}