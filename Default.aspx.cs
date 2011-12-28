using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public SqlDataAdapter da;
    public DataSet ds;
    public string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnnpi_Click(object sender, EventArgs e)
    {
        try
        {
            sqlstr = "truncate table tbl_NPI";
            cmd = new SqlCommand(sqlstr, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            for (int j = 1; j <= 50; j++)
            {
                sqlstr = "SELECT floor(RAND((DATEPART(mm, GETDATE()) * 100000 )+ (DATEPART(ss, GETDATE()) * 1000 )+ DATEPART(ms, GETDATE()) ) * 1000000000)";
                ds = new DataSet();
                da = new SqlDataAdapter(sqlstr, conn);
                da.Fill(ds);

                string rdmcode = ds.Tables[0].Rows[0][0].ToString();
                //Random rnd = new Random();
                //string rdmcode = rnd.Next(999999999).ToString;
                //if (rdmcode.Length < 9)
                //{
                  //  for (int i = rdmcode.Length; i < 9; i++)
                    //{ 

                    //}
                //}
                int val, tot;
                tot = 0;
                for (int i = 9; i >= 1; i--)
                {
                    val = int.Parse(rdmcode.Substring(i - 1, 1));
                    if (i % 2 == 1)
                        val = val * 2;
                    if (val > 9)
                        val = val - 9;
                    tot = tot + val;
                }
                tot = tot + 24;
                tot = tot % 10;
                if (tot > 0)
                    tot = 10 - tot;

                string npicode = rdmcode + tot.ToString();

                sqlstr = "insert into tbl_NPI values('" + rdmcode + "','" + npicode + "')";
                cmd = new SqlCommand(sqlstr, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch { }
    }
}
