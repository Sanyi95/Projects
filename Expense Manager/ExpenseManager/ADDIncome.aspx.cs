﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseManager
{
    public partial class ADDIncome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != string.Empty && Session["UserName"] != null)
                {

                    if (!Page.IsPostBack)
                    {
                        BindmainExps();
                        BindGrid();
                    }
                }
                else
                {
                    Session.RemoveAll();
                    Session.Abandon();
                    Session["UserName"] = "";
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                SqlCommand cmd = new SqlCommand("sp_getmainEIncome", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlMainCategory.DataSource = dt;
                    ddlMainCategory.DataTextField = "IncomeType_Desc";
                    ddlMainCategory.DataValueField = "IncTypeID";
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMainCategory.SelectedIndex != -1 && ddlMainCategory.SelectedIndex != 0 && TextBox1.Text != string.Empty)
                {
                    SqlConnection con = new SqlConnection(GetConnectionString());
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("Insert into dbo.tblIncome(IncomeTypeID,IncomeType_Desc) values(@IncomeTypeID,@IncomeType_Desc) ", con);
                    cmd.Parameters.AddWithValue("@IncomeTypeID", ddlMainCategory.SelectedValue);
                    cmd.Parameters.AddWithValue("@IncomeType_Desc", TextBox1.Text.Trim());
                    int i = 0;
                    i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        Response.Write("<script>alert('Record saved successfully')</script>");
                        TextBox1.Text = string.Empty;
                        ddlMainCategory.SelectedIndex = 0;

                        TextBox1.Focus();
                        BindGrid();
                    }
                    else
                    {
                        Response.Write("<script>alert('Record Not saved .....Error')</script>");
                    }
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('plz select main category and enter sub category');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        private void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                DataSet ds = new DataSet();
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getIncomeCat", con);
                cmd.CommandType = CommandType.StoredProcedure;

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