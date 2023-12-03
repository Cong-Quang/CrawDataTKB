using Newtonsoft.Json;
public class Data
{
    private static Data gi;

    private string urlFile = "data.json";

    public UserInfo userInfo = new UserInfo
    {
        Username = "userName",
        Password = "PassWord",
        Url = "link"
    };

    public static Data Gi() 
    {
        if (gi == null) gi = new Data();
        return gi;
    }

    public Data()
    {
        string json = JsonConvert.SerializeObject(userInfo);
        if (!File.Exists(urlFile))
        {
            File.WriteAllText(urlFile, json);
        }
        ReadData();
    }
    private void ReadData()
    {
        string jsonContent = File.ReadAllText(urlFile);
        try
        {
            // Chuyển đổi nội dung JSON thành đối tượng UserInfo
            userInfo = JsonConvert.DeserializeObject<UserInfo>(jsonContent);

            // In ra thông tin từ đối tượng UserInfo
            Console.Title = $"Username: {userInfo.Username}";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra khi đọc file JSON: " + ex.Message);
        }
    }
}
public class UserInfo
{

    public string Username { get; set; }

    public string Password { get; set; }

    public string Url { get; set; }
}

