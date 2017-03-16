﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>s
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ProcessCalc();
        }

        private void ProcessCalc()
        {
            Int32 Var1 = Convert.ToInt32(textBoxInput1.Text) + Convert.ToInt32(txtBoxInput2.Text);
            txtBoxDisplay.Text = Convert.ToString(Var1);
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            ProcessSubtract();
        }

        private void ProcessSubtract()
        {
            int var1Verify;
            int var2Verify;
            int result;

            if (Int32.TryParse(textBoxInput1.Text, out var1Verify) && (Int32.TryParse(txtBoxInput2.Text, out var2Verify)))
            {
                result = var1Verify - var2Verify;
                txtBoxDisplay.Text = Convert.ToString(result);
            }
            else
            {
                txtBoxDisplay.Text = "Invalid integer used. Please use numerals 0-9 only";
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            int var1Verify;
            int var2Verify;
            int result;

            if (Int32.TryParse(textBoxInput1.Text, out var1Verify) && (Int32.TryParse(txtBoxInput2.Text, out var2Verify)))
            {
                result = var1Verify * var2Verify;
                txtBoxDisplay.Text = Convert.ToString(result);
            }
            else
            {
                txtBoxDisplay.Text = "Invalid integer used. Please use numerals 0-9 only";
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            double var1Verify;
            double var2Verify;
            double result;

            if (Double.TryParse(textBoxInput1.Text, out var1Verify) && (Double.TryParse(txtBoxInput2.Text, out var2Verify)))
            {
                result = var1Verify / var2Verify;
                txtBoxDisplay.Text = Convert.ToString(result);
            }
            else
            {
                txtBoxDisplay.Text = "Invalid integer used. Please use numerals 0-9 only";
            }
        }

        async private void btnCourse1_Click(object sender, RoutedEventArgs e)
        {
            BL_PageContent.Course1();
            txtBoxCourse.Text = BL_PageContent.VarOutput + "\n" + BL_PageContent.CreditsPrereq;
        }

        async private void btnCourse2_Click(object sender, RoutedEventArgs e)
        {
            BL_PageContent.Course2();
            txtBoxCourse.Text = BL_PageContent.VarOutput + "\n" + BL_PageContent.CreditsPrereq;
        }

        async void btnCourse3_Click(object sender, RoutedEventArgs e)
        {
            BL_PageContent.Course3();
            txtBoxCourse.Text = BL_PageContent.VarOutput + "\n" + BL_PageContent.CreditsPrereq;
        }

        public void hypLinkPage2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Faculty));
        }

        IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
        MobileServiceCollection<TodoItem, TodoItem> items;


        public class Contact
        {
            public int ID { get; set; }
            public string NAME { get; set; }
            public string EMAILADDRESS { get; set; }
        }


        public class TodoItem
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public bool Complete { get; set; }
        }

        async private void Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TodoItem item = new TodoItem
                {
                    Text = txtBoxItem.Text,
                    Complete = false
                };
                await App.MobileService.GetTable<TodoItem>().InsertAsync(item);
                var dialog = new MessageDialog("Successful!");
                await dialog.ShowAsync();
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }

        public void GetDBSync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://bonifs1easytableswebappservice.azurewebsites.net");

                var json = client.GetStringAsync("/").Result;
                var contacts = JsonConvert.DeserializeObject<Contact[]>(json);
            }
        }


        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .Where(TodoItem => TodoItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListItems.ItemsSource = items;
                this.btnRefresh.IsEnabled = true;
            }
        }

        private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            await UpdateCheckedTodoItem(item);
        }

        private async Task UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
            ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

            //await SyncAsync(); // offline sync
        }

        async private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await RefreshTodoItems();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewPage));

        }

        private void todo2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserAuth));
        }
    }
}
