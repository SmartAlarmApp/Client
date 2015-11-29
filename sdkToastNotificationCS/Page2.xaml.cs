/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;

namespace sdkToastNotificationCS
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Event handler for when this page is navigated to.  Looks to see
        /// if the tile exists and set the check box appropriately.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //  If we navigated to this page
            // from the MainPage, the DefaultTitle parameter will be "FromMain".  If we navigated here
            // when the secondary Tile was tapped, the parameter will be "FromTile".
            //textBlockFrom.Text = "Navigated here from " + this.NavigationContext.QueryString["NavigatedFrom"];

        }

        async private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri("http://alarm.fr.to/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YW5vbnltb3VzOmFub255bW91cw==");

                var message = new
                {
                    arrivalTime = textBox.Text,
                    breakfastTime = textBox1.Text

                };
                var json_object = JsonConvert.SerializeObject(message);


                HttpContent content = new StringContent(json_object.ToString(), Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                //HttpResponseMessage response = httpClient.PostAsync("api", content).Result;
                var response = await httpClient.PostAsync("http://alarm.fr.to/api", content);
                //string statusCode = response.StatusCode.ToString();

                //response.EnsureSuccessStatusCode();
                //Task<string> responseBody = response.Content.ReadAsStringAsync();
            }
        }
    }
}
