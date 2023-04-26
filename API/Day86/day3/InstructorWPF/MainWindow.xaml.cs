using Azure;
using InstructorWPF.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace InstructorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client;
        public string jwt;
        public MainWindow(string _jwt)
        {
            InitializeComponent();
            client = new HttpClient();
            jwt = _jwt;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            client.BaseAddress = new Uri("https://localhost:7109/api/");

            HttpResponseMessage response = client.GetAsync("Instructor").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Instructor> instructors = response.Content.ReadAsAsync<List<Instructor>>().Result;

                getall.ItemsSource = instructors;

                // Allow the user to add and delete rows
                getall.CanUserAddRows = true;
                getall.CanUserDeleteRows = true;
                HttpResponseMessage mess = client.GetAsync("Department").Result;
                if(mess.IsSuccessStatusCode)
                {
                    List<Department> departments = mess.Content.ReadAsAsync<List<Department>>().Result;
                    dep.DisplayMemberPath = "Name";
                    dep.SelectedValuePath = "Id";
                    dep.ItemsSource = departments;

                }


            }
            else
            {
                MessageBox.Show("OPPs !!!");
            }

            getall.CellEditEnding += getall_CellEditEnding;
            getall.SelectionChanged += DataGrid_SelectionChanged;
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDepartment = (Department)dep.SelectedItem;
            int selectedDepartmentId = selectedDepartment.Id;

            Instructor instructor = new Instructor() {
                Name = name.Text,
                Email = email.Text,
                Phone = phone.Text,
                Password = pass.Text,
                Address = address.Text,
                SSN = ssn.Text,
                DOB = DateTime.Parse(dob.Text), // convert string to DateTime
                Age = int.Parse(age.Text), // convert string to int
                Salary = double.Parse(salary.Text), // convert string to double
                DepartmentId = selectedDepartmentId

            };
            HttpResponseMessage res = client.PostAsJsonAsync("Instructor", instructor).Result;
            if(res.IsSuccessStatusCode)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("OPPs !!!");
            }
        
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void getall_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Instructor selectedInstructor = getall.SelectedItem as Instructor;

            if (selectedInstructor != null)
            {
                // Get the updated value
                string columnName = e.Column.Header.ToString();
                string newValue = ((TextBox)e.EditingElement).Text;

                // Update the selected instructor
                switch (columnName)
                {
                    case "Name":
                        selectedInstructor.Name = newValue;
                        break;
                    case "Email":
                        selectedInstructor.Email = newValue;
                        break;
                    case "Phone":
                        selectedInstructor.Phone = newValue;
                        break;
                    case "Password":
                        selectedInstructor.Password = newValue;
                        break;
                    case "Address":
                        selectedInstructor.Address = newValue;
                        break;
                    case "SSN":
                        selectedInstructor.SSN = newValue;
                        break;
                    case "DOB":
                        selectedInstructor.DOB = DateTime.Parse(newValue);
                        break;
                    case "Age":
                        selectedInstructor.Age = int.Parse(newValue);
                        break;
                    case "Salary":
                        selectedInstructor.Salary = double.Parse(newValue);
                        break;
                    case "Department":
                        Department selectedDepartment = (Department)dep.SelectedItem;
                        selectedInstructor.DepartmentId = selectedDepartment.Id;
                        break;
                    default:
                        break;
                }

                // Send a PUT request to update the record
                var instructorJson = JsonConvert.SerializeObject(selectedInstructor);
                var content = new StringContent(instructorJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response =await client.PutAsync($"Instructor/{selectedInstructor.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Updated successfully.");
                }
                else
                {
                    MessageBox.Show($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show($"Error message: {errorMessage}");
                }
            }
        }

        private async void delete_Click(object sender, RoutedEventArgs e)
        {
            Instructor selectedInstructor = getall.SelectedItem as Instructor;

            if (selectedInstructor != null)
            {
                // Send a DELETE request to remove the record
                HttpResponseMessage response = await client.DeleteAsync($"Instructor/{selectedInstructor.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Deleted successfully.");
                   
                }
                else
                {
                    MessageBox.Show($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show($"Error message: {errorMessage}");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string idSearch = ids.Text.Trim();
           

            // Determine which search method to use
            string apiUrl = "";
            if (!string.IsNullOrEmpty(idSearch))
            {
                apiUrl = $"https://localhost:7109/api/Instructor/{idSearch}";
            }
       
            else
            {
                MessageBox.Show("Please enter an ID to search for.");
                return;
            }

            // Send a GET request to the API
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Parse the response content as an Instructor object
                string responseContent = await response.Content.ReadAsStringAsync();
                Instructor searchResult = JsonConvert.DeserializeObject<Instructor>(responseContent);

                // Create a list to hold the search result
                List<Instructor> searchResults = new List<Instructor>();

                // If an Instructor object was returned, add it to the list
                if (searchResult != null)
                {
                    searchResults.Add(searchResult);
                }

                // Bind the search results to the data grid
                search.ItemsSource = searchResults;
            }
            else
            {
                MessageBox.Show($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                string errorMessage = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show($"Error message: {errorMessage}");
            }
        }

        private async void searchname1_Click(object sender, RoutedEventArgs e)
        {
            string nameSearch = names.Text.Trim();
            string apiUrl = "";
            if (!string.IsNullOrEmpty(nameSearch))
            {
                apiUrl = $"https://localhost:7109/api/Instructor/{nameSearch}";
            }
            else
            {
                MessageBox.Show("Please enter a name to search for.");
                return;
            }

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Parse the response content as an Instructor object
                string responseContent = await response.Content.ReadAsStringAsync();
                Instructor searchResult = JsonConvert.DeserializeObject<Instructor>(responseContent);

                // Create a list to hold the search result
                List<Instructor> searchResults = new List<Instructor>();

                // If an Instructor object was returned, add it to the list
                if (searchResult != null)
                {
                    searchResults.Add(searchResult);
                }

                // Bind the search results to the data grid
                g2.ItemsSource = searchResults;
            }
            else
            {
                MessageBox.Show($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
                string errorMessage = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show($"Error message: {errorMessage}");
            }
        }
    }
}