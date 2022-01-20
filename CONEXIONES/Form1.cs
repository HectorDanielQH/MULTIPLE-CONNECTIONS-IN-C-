using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Configuration;
using MongoDB.Driver;

namespace CONEXIONES
{
    public partial class Form1 : Form
    {
        private int cotrl=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ToString());
            SqlCommand comando = new SqlCommand("select * from usuario", conexion);
            comando.CommandType = CommandType.Text;
            DataSet datos = new DataSet();
            conexion.Open();
            SqlDataAdapter adapta = new SqlDataAdapter(comando);
            adapta.Fill(datos);
            conexion.Close();
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            if (cotrl == 0)
            {
                textBox1.DataBindings.Add("Text", bindingSource1, "CI");
                textBox2.DataBindings.Add("Text", bindingSource1, "NOMBRE");
                textBox3.DataBindings.Add("Text", bindingSource1, "APELLIDO");
                textBox4.DataBindings.Add("Text", bindingSource1, "EDAD");
            }
            cotrl = 1;
            MessageBox.Show("se cargo correctamente");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conex = new MySqlConnection(ConfigurationManager.ConnectionStrings["MYSQL"].ToString());
            MySqlCommand comando = new MySqlCommand("select * from usuario;", conex);
            comando.CommandType = CommandType.Text;
            DataSet datos = new DataSet();
            conex.Open();
            MySqlDataAdapter adapta = new MySqlDataAdapter(comando);
            adapta.Fill(datos);
            conex.Close();
            DataTable tab = new DataTable();
            tab = datos.Tables[0];
            MessageBox.Show(tab.PrimaryKey.ToString());
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            MessageBox.Show("se cargo correctamente");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlConnection cone = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["POSTGRES"].ToString());
            NpgsqlCommand comando = new NpgsqlCommand("select * from usuario;", cone);
            comando.CommandType = CommandType.Text;
            DataSet datos = new DataSet();
            cone.Open();
            NpgsqlDataAdapter adapta = new NpgsqlDataAdapter(comando);
            adapta.Fill(datos);
            cone.Close();
            bindingSource1.DataSource = datos.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            MessageBox.Show("se cargo correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
