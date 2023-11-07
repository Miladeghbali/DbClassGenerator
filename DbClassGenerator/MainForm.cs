using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbClassGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UserIDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserIDTextBox.Enabled = PasswordTextBox.Enabled = UserIDCheckBox.Checked;
            if (UserIDCheckBox.Checked)
                UserIDTextBox.Focus();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            using (var connection = new SqlConnection(GetConnectionString("master")))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM sys.databases ", connection);
                var reader = command.ExecuteReader();
                DataBasesComboBox.Items.Clear();
                while (reader.Read())
                {
                    DataBasesComboBox.Items.Add(reader["Name"]);
                }
                DataBasesComboBox.Enabled = true;
            }
        }
        private string GetConnectionString(string databaseName)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = DataSourceTextBox.Text;
            connectionStringBuilder.InitialCatalog = databaseName;
            connectionStringBuilder.MultipleActiveResultSets = true;
            if (UserIDCheckBox.Checked)
            {
                connectionStringBuilder.IntegratedSecurity = false;
                connectionStringBuilder.UserID = UserIDTextBox.Text;
                connectionStringBuilder.Password = PasswordTextBox.Text;
            }
            else
                connectionStringBuilder.IntegratedSecurity = true;
        return connectionStringBuilder.ConnectionString;
        }
        private void DataBasesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connectionString = GetConnectionString(DataBasesComboBox.SelectedItem.ToString());
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", connection);
                var reader = command.ExecuteReader();
                TablesCheckedListBox.Items.Clear();
                while (reader.Read())
                {
                    var schema = reader["TABLE_SCHEMA"];
                    var table = reader["TABLE_NAME"];
                    TablesCheckedListBox.Items.Add(schema + "." + table);
                }
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() != DialogResult.OK)
                return;
           
            foreach (var item in TablesCheckedListBox.CheckedItems)
            {
                var text = item.ToString();
                var schema = text.Split('.')[0];
                var table= text.Split('.')[1];
                var columns = GetTableColumns(schema, table);
                GereateEntities(folderBrowser.SelectedPath, schema, table, columns);
                GenerateRepositoryInterFaces(folderBrowser.SelectedPath, schema, table, columns);
                GenerateRepositories(folderBrowser.SelectedPath, schema, table, columns);
            }
        

        }
        private void GenerateRepositories(string generatePath, string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatePath, "Repositories");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            List<string> classLines = new List<string>();
            classLines.Add("using System;");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("using System.Data.SqlClient;");
            classLines.Add("");
            classLines.Add("namespace " + RootNamespaceTextBox.Text + ".Repositories");
            classLines.Add("{");
            classLines.Add("    public class " + table + "Repository : DataLayer.GenericRepository<Entities." + GetSingularName(table) + ">, RepositoryAbstracts.I"+table+"Repository");
            classLines.Add("    {");
            classLines.Add("        public "+table+ "Repository():base(\"name=DbConnectionString\"){}");
            foreach (var column in columns)
            {
                var dataType = ConvertsqlTypeToClr(column.DataType, column.IsNullable);
                classLines.Add("       public List<Entities." + GetSingularName(table) + ">GetBy" + column.Name + "(" + ConvertsqlTypeToClr(column.DataType, column.IsNullable) + " value)");
                classLines.Add("       {");
                if (dataType== "string")
                {
                    classLines.Add("         return RunQuery(\"SELECT * FROM[" + schema + "].[" + table + "] WHERE [" + column.Name + "] LIKE @Value\", new SqlParameter(\"Value\", value));");
                }
                else
                {
                    classLines.Add("         return RunQuery(\"SELECT * FROM[" + schema + "].[" + table + "] WHERE [" + column.Name + "] = @Value\", new SqlParameter(\"Value\", value));");
                }
                classLines.Add("       }");
               
            }
            classLines.Add("    }");
            classLines.Add("}");
            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);
        }
        private void GenerateRepositoryInterFaces(string generatePath, string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatePath, "Abstracts");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            List<string> classLines = new List<string>();
            classLines.Add("using System;");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("");
            classLines.Add("namespace " + RootNamespaceTextBox.Text + ".RepositoryAbstracts");
            classLines.Add("{");
            classLines.Add("    public interface I" + table+ "Repository : DataLayer.IRepository<Entities." + GetSingularName(table) + ">");
            classLines.Add("    {");
            foreach (var column in columns)
            {
                classLines.Add("        List<Entities." + GetSingularName(table)+">GetBy"+column.Name+"("+ ConvertsqlTypeToClr(column.DataType, column.IsNullable)+" value);");
            }
            classLines.Add("    }");
            classLines.Add("}");
            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);
        }
        private void GereateEntities(string generatePath,string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatePath, "Entites");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            List<string> classLines = new List<string>();
            classLines.Add("using System;");
            classLines.Add("");
            classLines.Add("namespace " + RootNamespaceTextBox.Text + ".Entities");
            classLines.Add("{");
            classLines.Add("    [DataLayer.Table(\"" + schema + "\",\"" + table + "\")]");
            classLines.Add("    public class " + GetSingularName(table));
            classLines.Add("    {");
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey)
                {
                    classLines.Add("        [DataLayer.PrimaryKey]");
                }
                if (column.IsComputed)
                {
                    classLines.Add("        [DataLayer.ComputedColumn]");
                }
                classLines.Add("        public " + ConvertsqlTypeToClr(column.DataType, column.IsNullable) + " " + column.Name + " { get; set; }");
            }
            classLines.Add("    }");
            classLines.Add("}");
            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);

        }
        private string ConvertsqlTypeToClr(string type,bool nullable)
        {
            switch (type)
            {
                case "int":
                    return nullable ? "int?" : "int";
                case "bigint":
                    return nullable ? "long?" : "long";
                case "datetime":
                case "date":
                case "datetime2":
                    return nullable ? "DateTime?" : "DateTime";
                case "nvarchar":
                case "nchar":
                case "varchar":
                case "char":
                    return "string";
                case "bit":
                    return nullable ? "bool?" : "bool";
                case "binary":
                case "image":
                    return "byte[]";
                case "decimal":
                    return nullable ? "decimal?" : "decimal";
                case "float":
                    return nullable ? "float?" : "float";
            }
            return "object";
        }
        private string GetSingularName(string name)
        {
            if(name.EndsWith("ies"))
            {
                return name.Substring(0, name.Length - 3) + "y";
            }
            return name.Substring(0, name.Length - 1);
        }
        private List<ColumnModel> GetTableColumns(string schema, string tableName)
        {
            var columns = new List<ColumnModel>();
            using(var connection=new SqlConnection(GetConnectionString(DataBasesComboBox.SelectedItem.ToString())))
            {
                connection.Open();
                List<string> primaryKeyColumns = new List<string>();
                var keyscommand = new SqlCommand("SELECT tc.TABLE_SCHEMA,tc.TABLE_NAME,ccu.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS ccu ON ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME  WHERE tc.TABLE_SCHEMA = N'"+schema+"'AND tc.TABLE_NAME = N'"+tableName+"' AND tc.CONSTRAINT_TYPE = N'PRIMARY KEY'", connection);
                var keysReader = keyscommand.ExecuteReader();
                while (keysReader.Read())
                {
                    primaryKeyColumns.Add(keysReader["COLUMN_NAME"].ToString());
                }
                List<string> computedcolumns = new List<string>();
                var computedCommand = new SqlCommand("SELECT name FROM sys.columns WHERE object_id=OBJECT_ID('"+schema+"."+tableName+"') AND (is_identity=1 OR is_computed=1)", connection);
                var computedReader = computedCommand.ExecuteReader();
                while (computedReader.Read())
                {
                    computedcolumns.Add(computedReader["name"].ToString());
                }
                var command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA=N'"+schema+"' AND TABLE_NAME=N'"+tableName+"'", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var columnModel = new ColumnModel()
                    {
                        IsPrimaryKey=primaryKeyColumns.Any(col=>col.Equals(reader["COLUMN_NAME"])),
                        IsComputed= computedcolumns.Any(col=>col.Equals(reader["COLUMN_NAME"])),
                        Name = reader["COLUMN_NAME"].ToString(),
                        DataType = reader["DATA_TYPE"].ToString(),
                        IsNullable = reader["IS_NULLABLE"].ToString()== "YES",
                    };
                    columns.Add(columnModel);
                }
            }
            return columns;
        }
        public class ColumnModel
        {
            public string Name { get; set; }
            public string DataType { get; set; }
            public bool IsPrimaryKey { get; set; }
            public bool IsComputed { get; set; }
            public bool IsNullable { get; set; }
        }
    }
}
