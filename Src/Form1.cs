using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class AllPeople
        {
            public Person[] allp { get; set; }
        }

        List<Person> people = new List<Person>();
        string path = "C:\\Users\\Ivan\\source\\repos\\Lab3\\Lab3\\In2.json";
        private void Form1_Load(object sender, EventArgs e)
        {
            Person p = new Person();
            string stringList = File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab3\\Lab3\\In2.json");
            AllPeople PL = JsonConvert.DeserializeObject<AllPeople>(File.ReadAllText("C:\\Users\\Ivan\\source\\repos\\Lab3\\Lab3\\In2.json"));
            foreach (var Person in PL.allp)
            {
                listBox1.Items.Add(Person.FirstName); 
                people.Add(Person);
            };
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                Person p = new Person();
                p.FirstName = tbName.Text;
                p.Address = tbAddress.Text;
                p.City = tbCity.Text;
                p.State = tbState.Text;
                p.ZipCode = tbZipCode.Text;
                p.Email = tbEmail.Text;
                p.PhoneNumber = tbNumber.Text;
                p.Info = tbInfo.Text;
                people.Add(p);
                listBox1.Items.Add(p.FirstName);
                string serialized = JsonConvert.SerializeObject(people, Formatting.Indented);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                   byte[] array = System.Text.Encoding.UTF8.GetBytes(serialized);
                   fstream.Write(array, 0, array.Length);
                }
                tbName.Text = "";
                tbAddress.Text = "";
                tbCity.Text = "";
                tbState.Text = "";
                tbZipCode.Text = "";
                tbEmail.Text = "";
                tbNumber.Text = "";
                tbInfo.Text = "";
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                tbName.Text = people[listBox1.SelectedIndex].FirstName;
                tbAddress.Text = people[listBox1.SelectedIndex].Address;
                tbCity.Text = people[listBox1.SelectedIndex].City;
                tbState.Text = people[listBox1.SelectedIndex].State;
                tbZipCode.Text = people[listBox1.SelectedIndex].ZipCode;
                tbEmail.Text = people[listBox1.SelectedIndex].Email;
                tbNumber.Text = people[listBox1.SelectedIndex].PhoneNumber;
                tbInfo.Text = people[listBox1.SelectedIndex].Info;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                people[listBox1.SelectedIndex].FirstName = tbName.Text;
                people[listBox1.SelectedIndex].Address = tbAddress.Text;
                people[listBox1.SelectedIndex].City = tbCity.Text;
                people[listBox1.SelectedIndex].State = tbState.Text;
                people[listBox1.SelectedIndex].ZipCode = tbZipCode.Text;
                people[listBox1.SelectedIndex].Email = tbEmail.Text;
                people[listBox1.SelectedIndex].PhoneNumber = tbNumber.Text;
                people[listBox1.SelectedIndex].Info = tbInfo.Text;
                listBox1.Items[listBox1.SelectedIndex] = tbName.Text;
                string serialized = JsonConvert.SerializeObject(people, Formatting.Indented);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(serialized);
                    fstream.Write(array, 0, array.Length);
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int del = listBox1.SelectedIndex;
                people.RemoveAt(del);
                listBox1.Items.RemoveAt(del);
                string serialized = JsonConvert.SerializeObject(people, Formatting.Indented);
                File.WriteAllText(path, null);
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.UTF8.GetBytes(serialized);
                    fstream.Write(array, 0, array.Length);
                }
                tbName.Text = "";
                tbAddress.Text = "";
                tbCity.Text = "";
                tbState.Text = "";
                tbZipCode.Text = "";
                tbEmail.Text = "";
                tbNumber.Text = "";
                tbInfo.Text = "";
            }
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
    }
}