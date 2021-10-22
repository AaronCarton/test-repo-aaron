using DEVPROG_LAB05_Ex01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DEVPROG_LAB05_Ex01.Repositories
{
    public static class TrelloRepository
    {
        private const string _APIKEY = "053b0850b5e2a3eb10e0318e11c030db";
        private const string _USERTOKEN = "3c8719adb647d1a30a0dd4faa438b7ee8984630c28930019f486cb3b5b22231f";
        private const string _BASEURI = "https://api.trello.com/1/";

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public static async Task<List<TrelloBoard>> GetTrelloBoardsAsync()
        {
            string uri = $"{_BASEURI}/members/my/boards/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(uri);

                    List<TrelloBoard> l = JsonConvert.DeserializeObject<List<TrelloBoard>>(json);
                    return l;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static async Task<List<TrelloList>> GetTrelloListsAsync(string BoardId)
        {
            string uri = $"{_BASEURI}/boards/{BoardId}/lists/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(uri);

                    List<TrelloList> l = JsonConvert.DeserializeObject<List<TrelloList>>(json);
                    return l;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static async Task<List<TrelloCard>> GetTrelloCardsAsync(string ListId)
        {
            string uri = $"{_BASEURI}/lists/{ListId}/cards/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(uri);

                    List<TrelloCard> l = JsonConvert.DeserializeObject<List<TrelloCard>>(json);
                    return l;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static async Task<TrelloCard> GetTrelloCardByIdAsync(string cardId)
        {
            string uri = $"{_BASEURI}/cards/{cardId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(uri);

                    TrelloCard l = JsonConvert.DeserializeObject<TrelloCard>(json);
                    return l;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static async Task UpdateCard(TrelloCard card)
        {
            string uri = $"{_BASEURI}/cards/{card.CardId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(uri, content);

                    if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
