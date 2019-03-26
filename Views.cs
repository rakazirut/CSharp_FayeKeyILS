﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FayeKeyILS
{
    public partial class Views : Form
    {
        // Instance of the DatabaseConnector class we made
        DatabaseConnector dbc = new DatabaseConnector();
        public Views()
        {
            InitializeComponent();
        }

        private void Views_Load(object sender, EventArgs e)
        {
            List<Patron> patrons = new List<Patron>();

            // TODO: Create actual FullName property in the Patron object so it can be displayed everywhere, like here.
            patrons = dbc.GetFullPatronInfo();
            // Populates listbox with patron info from DB
            lst_Patrons.DataSource = patrons;
            lst_Patrons.DisplayMember = "patronFirstName";
        }

        private void lst_Patrons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Same principle as the update patron fields in Add.cs
            List<Patron> allPatrons = new List<Patron>();
            Patron selectedPatron = (Patron)lst_Patrons.SelectedItem;

            allPatrons = dbc.GetFullPatronInfo();

            lbl_PatronID.Text = selectedPatron.Id.ToString();
            lbl_Name.Text = selectedPatron.patronFirstName.ToString() + " " + selectedPatron.patronLastName.ToString();

            if (selectedPatron.patronEmail == null)
            {
                lbl_email.Text = "";
            }
            else
            {
                lbl_email.Text = selectedPatron.patronEmail.ToString();
            }
            if (selectedPatron.patronPhone == null)
            {
                lbl_phone.Text = "";
            }
            else
            {
                lbl_phone.Text = selectedPatron.patronPhone.ToString();
            }

        }

        private void lst_Patrons_Format(object sender, ListControlConvertEventArgs e)
        {
            string fName = ((Patron)e.ListItem).patronFirstName.ToString();
            string lName = ((Patron)e.ListItem).patronLastName.ToString();
            e.Value = fName + " " + lName;
        }
    }
}
