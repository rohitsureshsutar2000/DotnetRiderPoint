namespace DALconnet;
using MySql.Data.MySqlClient;
using bol;

public class DBManager{
    public static List<Rider> GetAllRiders()
    {
        List<Rider> lst=new List<Rider>();
        MySqlConnection conn= new MySqlConnection();
        conn.ConnectionString="server=localhost;port=3306;user=root;password=welcome;database=riderpoint";
        string query="select * from rider_details";
        MySqlCommand command=new MySqlCommand(query,conn);


        try
        {
            conn.Open();
            MySqlDataReader ds=command.ExecuteReader();
            while(ds.Read())
            {
                int id=int.Parse(ds["Rider_id"].ToString());
                string name=ds["Name"].ToString();
                string mobile=ds["Mobile_no"].ToString();
                string address=ds["Address"].ToString();
                Rider r=new Rider{Rider_Id=id,Name=name,Mobile_no=mobile,Address=address};
                lst.Add(r);
            }
            // this.ViewData["sendRiderInfo"]=lst;
            
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
        return lst;

    }
}