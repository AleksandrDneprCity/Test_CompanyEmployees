using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_CompanyEmployees
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Load += MainForm_Load;
            treeDepartments.AfterSelect += TreeDepartments_AfterSelect;
            treeDepartments.MouseClick += TreeDepartments_MouseClick;
            dgvEmployees.ReadOnly = true;
        }

        private void MainForm_Load(object sender, EventArgs ea)
        {
            SqlServerContext sqlContext = new SqlServerContext();
            TreeNode Node = null;
            TreeNode NodeParent = treeDepartments.Nodes[0];
            int? parent_id = null;

            try
            {
                foreach (var Departments in sqlContext.Departments.OrderBy(dp => dp.id).OrderBy(dp => dp.parent_id))
                {
                    if (Departments.parent_id != parent_id)
                    {
                        parent_id = Departments.parent_id;
                        NodeParent = FindNode(parent_id, treeDepartments.Nodes);
                        if (NodeParent == null)
                            NodeParent = treeDepartments.Nodes[0];
                    }

                    Node = new TreeNode(Departments.name);
                    Node.Tag = Departments.id;

                    NodeParent.Nodes.Add(Node);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка подключения к БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            treeDepartments.ExpandAll();
        }

        private void TreeDepartments_AfterSelect(object sender, TreeViewEventArgs ea)
        {
            ShowEmployees((int?)ea.Node.Tag);
        }

        private void ShowEmployees(int? depart_id)
        {
            SqlServerContext sqlContext = new SqlServerContext();

            try
            {
                if (depart_id != null)
                {
                    var depcid = sqlContext.DepartContent.GroupBy(dc => dc.id_employee).Select(g => new { id = g.Max(gm => gm.id) });
                    var depcontent = sqlContext.DepartContent.Where(dc => depcid.Any(dpc => dpc.id == dc.id)).Where(dc => dc.id_depart == depart_id);
                    var employees = sqlContext.Employees.Where(em => depcontent.Any(dc => dc.id_employee == em.id) && em.date_dismissal == null);
                    dgvEmployees.DataSource = employees.ToList();
                }
                else
                    dgvEmployees.DataSource = sqlContext.Employees.ToList();

                /*
                var employees = sqlContext.Employees.Join(sqlContext.DepartContent, em => em.id, dc => dc.id_employee, (em, dc) => new
                {
                    em.id,
                    em.last_name,
                    Имя = em.first_name,
                    Отчество = em.middle_name,
                    Пол = em.gender
                });
                */

                //sqlContext.Employees.ElementAt(0).last_name.GetType().GetCustomAttributes(false).
                //dgvEmployees.DataSource = employees.ToList();

                //dgvEmployees.DataSource = (from em in sqlContext.Employees select new {em}).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        struct CONTEXT_MENU
        {
            public CONTEXT_MENU(string sName, string sText, bool bEnabled)
            {
                this.sName = sName;
                this.sText = sText;
                this.bEnabled = bEnabled;
            }

            public string sName;
            public string sText;
            public bool bEnabled;
        }

        private void TreeDepartments_MouseClick(object sender, MouseEventArgs ea)
        {
            if(ea.Button==MouseButtons.Right)
            {
                int? parent_depart_id = (int?)treeDepartments.SelectedNode.Tag;
                MenuItem mItem;
                Point pt = dgvEmployees.PointToClient(Cursor.Position);

                ContextMenu = new ContextMenu();
                CONTEXT_MENU[] ctxMenu =
                {
                    new CONTEXT_MENU("AddDepart", "Добавить дочернее подразделение", true),
                    new CONTEXT_MENU("EditDepart", "Изменить подразделение", parent_depart_id != null),
                    new CONTEXT_MENU("DeleteDepart", "Удалить подразделение", (parent_depart_id != null))
                };

                foreach(CONTEXT_MENU menu in ctxMenu)
                {
                    mItem = new MenuItem(menu.sText);
                    mItem.Name = menu.sName;
                    mItem.Enabled = menu.bEnabled;
                    mItem.Tag = parent_depart_id;
                    mItem.Click += MItem_Click;
                    ContextMenu.MenuItems.Add(mItem);
                }
                ContextMenu.Popup += ContextMenu_Popup;
                ContextMenu.Show(dgvEmployees, pt);
            }
        }

        private void ContextMenu_Popup(object sender, EventArgs ea)
        {
            ContextMenu = null;
        }

        private void MItem_Click(object sender, EventArgs ea)
        {
            ContextMenu = null;
            MenuItem mItem = (MenuItem)sender;

            switch(mItem.Name)
            {
                case "AddDepart":
                    AddDepartment((int?)mItem.Tag);
                    break;
                case "EditDepart":
                    EditDepartment((int)mItem.Tag);
                    break;
                case "DeleteDepart":
                    DeleteDepartment((int)mItem.Tag);
                    break;
            }
        }

        private TreeNode FindNode(int? id, TreeNodeCollection Nodes)
        {
            TreeNode NodeRet = null;
            if (id == null)
                return null;

            foreach(TreeNode Node in Nodes)
            {
                if ((int?)Node.Tag == id)
                    return Node;
                NodeRet = FindNode(id, Node.Nodes);
                if (NodeRet != null)
                    return NodeRet;
            }

            return null;
        }

        private void AddDepartment(int? parent_id)
        {
            TreeNode parentNode = treeDepartments.Nodes[0];
            string sParentName = "";
            if (parent_id != null)
                parentNode = FindNode(parent_id, treeDepartments.Nodes);
            if (parentNode != null)
                sParentName = parentNode.Text;
            else
                return;

            DepartmentForm dForm = new DepartmentForm("", sParentName);
            if (dForm.ShowDialog() == DialogResult.OK)
            {
                SqlServerContext sqlServer = new SqlServerContext();
                ModelDepartments departModel = new ModelDepartments();
                departModel.name = dForm.DepartmentName;
                departModel.parent_id = parent_id;
                departModel.date_creation = DateTime.Now;
                sqlServer.Departments.Add(departModel);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TreeNode node = new TreeNode(dForm.DepartmentName);
                node.Tag = departModel.id;
                parentNode.Nodes.Add(node);
            }
        }

        private void EditDepartment(int? id)
        {
            if (id == null)
                return;

            TreeNode node = FindNode(id, treeDepartments.Nodes);
            if (node == null || node.Parent == null)
                return;

            DepartmentForm dForm = new DepartmentForm(node.Text, node.Parent.Text);
            if (dForm.ShowDialog() == DialogResult.OK)
            {
                SqlServerContext sqlServer = new SqlServerContext();
                ModelDepartments departModel = sqlServer.Departments.Where(dc => dc.id == id).ToList()[0];
                departModel.name = dForm.DepartmentName;
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                node.Text = dForm.DepartmentName;
            }
        }

        private void DeleteDepartment(int? id)
        {
            if (id == null)
                return;

            TreeNode node = FindNode(id, treeDepartments.Nodes);
            if (node == null)
                return;

            if (node.Nodes.Count > 0)
            {
                MessageBox.Show("Нельзя удалить выбранное подразделение, т.к. у него есть дочерние подразделения.",
                    "Удаление подразделения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Вы действительно желаете удалить подразделение\r\n\"{node.Text}\" ?",
                "Удаление подразделения",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlServerContext sqlServer = new SqlServerContext();
                ModelDepartments modelDepart = sqlServer.Departments.Where(dp => dp.id == id).ToList()[0];
                sqlServer.Departments.Remove(modelDepart);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var depContent = sqlServer.DepartContent.Where(dc => dc.id_depart == id);
                foreach(ModelDepartContent depc in depContent)
                    sqlServer.DepartContent.Remove(depc);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                node.Remove();
            }
        }

        private void butAddEmp_Click(object sender, EventArgs ea)
        {
            SqlServerContext sqlServer = new SqlServerContext();
            TreeNode NodeDepart = treeDepartments.SelectedNode;

            List<string> listDepartments = sqlServer.Departments.OrderBy(dp => dp.id).Select(dp => dp.name).ToList();
            List<int> listDepartIDs = sqlServer.Departments.OrderBy(dp => dp.id).Select(dp => dp.id).ToList();

            EmployeeForm eForm;

            if (NodeDepart.Tag is Int32)
                eForm = new EmployeeForm(listDepartments, listDepartIDs, NodeDepart.Text);
            else
                eForm = new EmployeeForm(listDepartments, listDepartIDs);


            while (eForm.ShowDialog() == DialogResult.OK)
            {
                if (!IsEmployeeDataCorrect(eForm.EmployeeData.sPersonelNumber, eForm.EmployeeData.sTaxNumber, 0))
                    continue;

                ModelEmployees modelEmployees = new ModelEmployees();
                CopyEmployFromDataToModel(eForm.EmployeeData, modelEmployees);

                sqlServer.Employees.Add(modelEmployees);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (eForm.EmployeeData.iDepartID >= 0)
                //if(NodeDepart.Tag is Int32)
                {
                    ModelDepartContent modelDepartContent = new ModelDepartContent();

                    modelDepartContent.date_transfer = DateTime.Today;
                    modelDepartContent.id_depart = eForm.EmployeeData.iDepartID;
                    //modelDepartContent.id_depart = (int)NodeDepart.Tag;
                    modelDepartContent.id_employee = modelEmployees.id;
                    modelDepartContent.position = eForm.EmployeeData.sPosition;

                    sqlServer.DepartContent.Add(modelDepartContent);
                    try
                    {
                        sqlServer.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                ShowEmployees((int?)NodeDepart.Tag);
                return;
            }
        }

        private void butEditEmp_Click(object sender, EventArgs ea)
        {
            if (dgvEmployees.CurrentRow == null)
                return;

            int index = dgvEmployees.CurrentRow.Index;
            List<ModelEmployees> models = (List<ModelEmployees>)dgvEmployees.DataSource;
            int employee_id = models[index].id;
            SqlServerContext sqlServer = new SqlServerContext();
            ModelEmployees modelEmployee = sqlServer.Employees.Where(em => em.id == employee_id).ToList()[0];
            EmployeeForm.DATA data = CopyEmployFromModelToData(modelEmployee);

            data.listDepartments = sqlServer.Departments.OrderBy(dp => dp.id).Select(dp => dp.name).ToList();
            data.listDepartIDs = sqlServer.Departments.OrderBy(dp => dp.id).Select(dp => dp.id).ToList();

            int depart_id = -1;

            var depc = sqlServer.DepartContent.Where(dc => dc.id_employee == employee_id).OrderByDescending(dc => dc.id).ToList();
            if (depc.Count > 0)
            {
                depart_id = depc.ToList()[0].id_depart;
                data.sDepartment = sqlServer.Departments.Where(dp => dp.id == depart_id).ToList()[0].name;
                data.sPosition = depc.ToList()[0].position;
            }

            EmployeeForm eForm = new EmployeeForm(data);

            while (eForm.ShowDialog() == DialogResult.OK)
            {
                if (!IsEmployeeDataCorrect(eForm.EmployeeData.sPersonelNumber, eForm.EmployeeData.sTaxNumber, employee_id))
                    continue;

                CopyEmployFromDataToModel(eForm.EmployeeData, modelEmployee);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (depart_id != eForm.EmployeeData.iDepartID)
                {
                    ModelDepartContent modelDepContent = new ModelDepartContent();
                    modelDepContent.date_transfer = DateTime.Today;
                    modelDepContent.id_depart = eForm.EmployeeData.iDepartID;
                    modelDepContent.id_employee = employee_id;
                    modelDepContent.position = eForm.EmployeeData.sPosition;

                    sqlServer.DepartContent.Add(modelDepContent);
                    try
                    {
                        sqlServer.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                TreeNode NodeDepart = treeDepartments.SelectedNode;
                ShowEmployees((int?)NodeDepart.Tag);

                return;
            }
        }

        /*
        private void butDismissEmp_Click(object sender, EventArgs ea)
        {
            if (dgvEmployees.CurrentRow == null)
                return;

            int index = dgvEmployees.CurrentRow.Index;
            List<ModelEmployees> models = (List<ModelEmployees>)dgvEmployees.DataSource;
            int employee_id = models[index].id;
            SqlServerContext sqlServer = new SqlServerContext();
            ModelEmployees modelEmployee = sqlServer.Employees.Where(em => em.id == employee_id).ToList()[0];

            if (MessageBox.Show(
                "Вы действительно желаете уволить ценного сотрудника" +
                $"{modelEmployee.last_name} {modelEmployee.first_name} {modelEmployee.middle_name} ?",
                "Увольнение сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                modelEmployee.date_dismissal = DateTime.Today;
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                models[index] = modelEmployee;
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = models;
            }
        }
        */

        private void butDeleteEmp_Click(object sender, EventArgs ea)
        {
            if (dgvEmployees.CurrentRow == null)
                return;

            int index = dgvEmployees.CurrentRow.Index;
            List<ModelEmployees> models = (List<ModelEmployees>)dgvEmployees.DataSource;
            int employee_id = models[index].id;
            SqlServerContext sqlServer = new SqlServerContext();
            ModelEmployees modelEmployee = sqlServer.Employees.Where(em => em.id == employee_id).ToList()[0];

            if (MessageBox.Show(
                "Вы действительно желаете удалить ценного сотрудника\r\n" +
                $"{modelEmployee.last_name} {modelEmployee.first_name} {modelEmployee.middle_name} ?",
                "Удаление сотрудника",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sqlServer.Employees.Remove(modelEmployee);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var departContents = sqlServer.DepartContent.Where(dc => dc.id_employee == employee_id);
                foreach (ModelDepartContent depart in departContents)
                    sqlServer.DepartContent.Remove(depart);
                try
                {
                    sqlServer.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка сохранения в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                models.RemoveAt(index);
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = models;
                
            }
        }

        private bool IsEmployeeDataCorrect(string sPersonelNumber, string sTaxNumber, int employee_id)
        {
            SqlServerContext sqlServer = new SqlServerContext();

            var employees = sqlServer.Employees.Where(em => (em.personel_number == sPersonelNumber && em.id != employee_id)).ToList();
            if (employees.Count > 0)
            {
                MessageBox.Show("Введённый табельный номер уже занят", "Ошибка заполения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            employees = sqlServer.Employees.Where(em => (em.tax_number == sTaxNumber && em.id != employee_id)).ToList();
            if (employees.Count > 0)
            {
                MessageBox.Show("Введённый ИНН уже занят", "Ошибка заполения формы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private EmployeeForm.DATA CopyEmployFromModelToData(ModelEmployees model)
        {
            EmployeeForm.DATA data = new EmployeeForm.DATA();

            data.sPersonelNumber = model.personel_number;
            data.sTaxNumber = model.tax_number;

            data.sFirstName = model.first_name;
            data.sMiddleName = model.middle_name;
            data.sLastName = model.last_name;

            data.gender = (ModelEmployees.GenderName)model.gender;
            data.dtBirthDay = model.birth_day;
            data.sBirthPlace = model.birth_place;

            data.dtEmployDay = (DateTime)model.date_employment;
            data.bDismissal = model.date_dismissal != null;
            if (data.bDismissal)
            {
                data.dtDismisDay = (DateTime)model.date_dismissal;
                data.sDismisReason = model.reason_dismissal;
            }

            return data;
        }

        private void CopyEmployFromDataToModel(EmployeeForm.DATA data, ModelEmployees model)
        {
            model.personel_number = data.sPersonelNumber;
            model.tax_number = data.sTaxNumber;

            model.first_name = data.sFirstName;
            model.middle_name = data.sMiddleName;
            model.last_name = data.sLastName;

            model.gender = (ModelEmployees.GenderText)data.gender;

            model.birth_day = data.dtBirthDay;
            model.birth_place = data.sBirthPlace;

            model.date_employment = data.dtEmployDay;
            if (data.bDismissal)
            {
                model.date_dismissal = data.dtDismisDay;
                model.reason_dismissal = data.sDismisReason;
            }
            else
            {
                model.date_dismissal = null;
                model.reason_dismissal = null;
            }
        }
    }
}
