class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ChromeHead.Gi().OpenChrome("https://sinhvien.hutech.edu.vn/#/sinhvien/login/login");
        ChromeHead.Gi().Login(Data.Gi().userInfo.Username, Data.Gi().userInfo.Password);
        ChromeHead.Gi().goToURL("https://sinhvien.hutech.edu.vn/#/sinhvien/hoc-vu/thoi-khoa-bieu");
        ChromeHead.Gi().showMenu(); 
        ChromeHead.Gi().test(); 
        Console.ReadKey();
        ChromeHead.Gi().driver.Quit();
    }
}