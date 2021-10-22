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
    public partial class TrelloListsPage : ContentPage
    {
        TrelloBoard gBoard;
        public TrelloListsPage(TrelloBoard board)
        {
            InitializeComponent();
            gBoard = board;
            ShowLists();
        }

        private async void ShowLists()
        {
            List<TrelloList> lists = await TrelloRepository.GetTrelloListsAsync(gBoard.BoardId);
            lvwTrelloLists.ItemsSource = lists;
        }
        private void lvwTrelloLists_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwTrelloLists.SelectedItem != null)
            {
                TrelloList list = (TrelloList)lvwTrelloLists.SelectedItem;
                Navigation.PushAsync(new TrelloCardsPage(list));
                lvwTrelloLists.SelectedItem = null;
            }
        }
    }
}