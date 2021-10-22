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
    public partial class TrelloCardsPage : ContentPage
    {
        TrelloList gList;
        public TrelloCardsPage(TrelloList list)
        {
            InitializeComponent();
            gList = list;
            lblListName.Text = gList.Name;
            ShowCards();

        }

        private async void ShowCards()
        {
            List<TrelloCard> cards = await TrelloRepository.GetTrelloCardsAsync(gList.ListId);
            lvwCards.ItemsSource = cards;
        }

        private void btnGoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnCloseCard_Clicked(object sender, EventArgs e)
        {
            TrelloCard card = (sender as Button).BindingContext as TrelloCard;
            card.IsClosed = true;
            await TrelloRepository.UpdateCard(card);

        }
    }
}