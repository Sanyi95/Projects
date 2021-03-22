using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseManager
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindmainExps();
                BindGrid();
            }
        }
        private string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["Exp"].ConnectionString;
        }

        private void BindmainExps()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getmainExpense", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlMainCategory.DataSource = dt;
                    ddlMainCategory.DataTextField = "ExpenseType";
                    ddlMainCategory.DataValueField = "ExpenseTypeID";
                    ddlMainCategory.DataBind();
                    ddlMainCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    con.Close();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RunCode", "javascript:alert('Sorry No Records Found with this Keyword.....');", true);
                }
                con.Close();

            }
        }


        private void BindIncCategory()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select distinct IncomeTypeID,IncomeType_Desc from tblIncome where ExpenseTypeID=@MainCategory", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@MainCategory", ddlMainCategory.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlIncCategory.DataSource = dt;
                    ddlIncCategory.DataTextField = "IncomeType_Desc";
                    ddlIncCategory.DataValueField = "IncTypeID";
                    ddlIncCategory.DataBind();
                    ddlIncCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    con.Close();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RunCode", "javascript:alert('Sorry No Records Found with this Keyword.....');", true);
                }
                con.Close();

            }
        }

        protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindIncCategory();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlMainCategory.SelectedIndex != -1 && ddlMainCategory.SelectedItem.Text != "--Select--" && ddlIncCategory.SelectedIndex != -1 && ddlIncCategory.SelectedItem.Text != "--Select--" && txtDesc.Text != string.Empty && txtAmt.Text != string.Empty)
            {
                InsertRecord();
                BindGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RunCode", "javascript:alert('Sorry No Records Not saved.....');", true);
            }
        }


        private void InsertRecord()
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Insert into tblAllExpenses (ExpenseTypeID,IncomeTypeID,Description,amount,dateofPayment,CreatedBy) values(@ExpenseTypeID,@IncomeTypeID,@Description,@amount,@dateofPayment,@CreatedBy)", con);
            cmd.Parameters.AddWithValue("@ExpenseTypeID", ddlMainCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@IncTypeID ", ddlIncCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@Description ", txtDesc.Text);
            cmd.Parameters.AddWithValue("@amount ", Convert.ToDecimal(txtAmt.Text));
            cmd.Parameters.AddWithValue("@dateofPayment ", Convert.ToDateTime(DateTime.Now));
            cmd.Parameters.AddWithValue("@CreatedBy ", Session["UserName"].ToString());

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                Response.Write("<script>alert('record successfully saved');</script>");

                ddlMainCategory.SelectedIndex = -1;
                ddlIncCategory.SelectedIndex = -1;
                txtDesc.Text = string.Empty;
                txtAmt.Text = string.Empty;
            }
            else
            {
                Response.Write("<script>alert('record Not saved');</script>");
                ddlMainCategory.SelectedIndex = -1;
                ddlIncCategory.SelectedIndex = -1;
                txtDesc.Text = string.Empty;
                txtAmt.Text = string.Empty;
            }

        }




        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                DataSet ds = new DataSet();
                con.Open();
                SqlCommand cmd = new SqlCommand("select t1.ID,t2.ExpenseType as MainCategory,t3.IncomeType_Desc as IncCategory,t1.Description,t1.amount as Amount,t1.dateofPayment as Date,t1.CreatedBy from tblAllExpenses as t1 inner join tblExpenseType as t2 on t2.ExpenseTypeID=t1.ExpenseTypeID inner join tblIncome as t3 on t3.IncTypeID=t1.IncTypeID order by t1.ID desc ", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
    }

}

