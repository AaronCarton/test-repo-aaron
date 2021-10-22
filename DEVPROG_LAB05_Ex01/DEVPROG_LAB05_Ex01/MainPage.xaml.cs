using DEVPROG_LAB05_Ex01.Models;
using DEVPROG_LAB05_Ex01.Repositories;
using DEVPROG_LAB05_Ex01.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DEVPROG_LAB05_Ex01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TestModels();
            ShowBoards();
        }

        public async void TestModels()
        {
            Debug.WriteLine("-------------  BOARDS  ---------------");
            List<TrelloBoard> boards = await TrelloRepository.GetTrelloBoardsAsync();
            boards.ForEach(e => Debug.WriteLine(e.Name));

            TrelloBoard selectedBoard = boards.Find(e => e.IsFavorite);

            Debug.WriteLine("-------------  LISTS  ---------------");
            List<TrelloList> lists = await TrelloRepository.GetTrelloListsAsync(selectedBoard.BoardId);
            lists.ForEach(e => Debug.WriteLine(e.Name));

            Random rnd = new Random();
            TrelloList selectedList = lists[rnd.Next(lists.Count)];

            Debug.WriteLine("-------------  CARDS  ---------------");
            List<TrelloCard> cards = await TrelloRepository.GetTrelloCardsAsync(selectedList.ListId);
            cards.ForEach(e => Debug.WriteLine(e.Name));

            TrelloCard selectedCard = cards[rnd.Next(cards.Count)];
            TrelloCard card = await TrelloRepository.GetTrelloCardByIdAsync(selectedCard.CardId);
            Debug.WriteLine(card.IsClosed);

        }

        private async void ShowBoards()
        {
            List<TrelloBoard> boards = await TrelloRepository.GetTrelloBoardsAsync();
            lvwBoards.ItemsSource = boards;
        }

        private void lvwBoards_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwBoards.SelectedItem != null)
            {
                TrelloBoard board = (TrelloBoard)lvwBoards.SelectedItem;
                Navigation.PushAsync(new TrelloListsPage(board));
                lvwBoards.SelectedItem = null;
            }
        }
    }
}
