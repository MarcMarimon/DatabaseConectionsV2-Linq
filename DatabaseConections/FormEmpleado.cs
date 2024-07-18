using DatabaseConections;
using DatabaseConnections;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseConnections
{
    public partial class FormEmpleado : Form
    {
        private Servicios servicios;
        private employees empleadoModificar; 

        public FormEmpleado(employees empleado = null)
        {
            InitializeComponent();
            servicios = new Servicios();

            if (empleado != null)
            {
                empleadoModificar = empleado;
                CargarDatosEmpleado(empleado);
            }
            else
            {
                empleadoModificar = null;
                SetPlaceholderText();
            }

            CargarComboBoxes();
        }

        private void SetPlaceholderText()
        {
            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtEmail, "Email");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
            SetPlaceholder(txtSalary, "Salary");
            SetPlaceholder(txtManagerId, "Manager ID");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void CargarComboBoxes()
        {
            var departments = servicios.GetAllDepartments();
            cmbDepartmentId.DisplayMember = "DepartmentName";
            cmbDepartmentId.ValueMember = "DepartmentId";
            cmbDepartmentId.DataSource = departments;

            var jobs = servicios.GetAllJobs();
            cmbJobId.DisplayMember = "JobTitle";
            cmbJobId.ValueMember = "JobId";
            cmbJobId.DataSource = jobs;
        }

        private void CargarDatosEmpleado(employees empleado)
        {
            txtFirstName.Text = empleado.first_name;
            txtLastName.Text = empleado.last_name;
            txtEmail.Text = empleado.email;
            txtPhoneNumber.Text = empleado.phone_number;
            dtpHireDate.Value = empleado.hire_date;
            cmbJobId.SelectedValue = empleado.job_id;
            txtSalary.Text = empleado.salary.ToString();
            txtManagerId.Text = empleado.manager_id.HasValue ? empleado.manager_id.ToString() : "";
            cmbDepartmentId.SelectedValue = empleado.department_id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            employees empleado = new employees
            {
                first_name = txtFirstName.Text,
                last_name = txtLastName.Text,
                email = txtEmail.Text,
                phone_number = txtPhoneNumber.Text,
                hire_date = DateTime.Parse(dtpHireDate.Text),
                job_id = (int)cmbJobId.SelectedValue,
                salary = decimal.Parse(txtSalary.Text),
                manager_id = string.IsNullOrEmpty(txtManagerId.Text) ? (int?)null : int.Parse(txtManagerId.Text),
                department_id = (int)cmbDepartmentId.SelectedValue
            };

            bool success = false;
            if (empleadoModificar == null)
            {
                success = servicios.InsertEmployee(empleado);
            }
            else
            {
                empleado.employee_id = empleadoModificar.employee_id; 
                success = servicios.UpdateEmployee(empleado);
            }

            if (success)
            {
                MessageBox.Show("Empleado guardado correctamente en la base de datos.");
                SetPlaceholderText();
                Close(); 
            }
            else
            {
                MessageBox.Show("No se pudo guardar el empleado en la base de datos.");
            }
        }
    }
}
