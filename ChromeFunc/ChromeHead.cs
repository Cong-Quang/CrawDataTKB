using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
public class ChromeHead
{
    public IWebDriver driver;
    public IWebElement selectElement;
    public IList<IWebElement> options;
    private static ChromeHead gi;
    public static ChromeHead Gi()
    {
        if (gi == null) gi = new ChromeHead();
        return gi;
    }
    public void OpenChrome(string url)
    {
        var driverService = ChromeDriverService.CreateDefaultService();
        driverService.HideCommandPromptWindow = true;
        ChromeOptions op = new ChromeOptions();
        op.AddArguments("--disable-notifications");
        op.AddArgument("headless");
        driver = new ChromeDriver(driverService, op);
        driver.Navigate().GoToUrl(url);
    }
    public void Wait_For_Javascript()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        wait.Until((x) =>
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        });
    }
    public void SleepRandom(int timeMin, int timeMax)
    {
        Random rnd = new Random();
        int trd1 = rnd.Next(timeMin, timeMax);
        Thread.Sleep(trd1);
    }
    public void CloseChrom()
    {
        driver.Close();
    }
    public void CloseChrom(bool QuitCH)
    {
        if (QuitCH == false)
        {
            driver.Close();
        }
        else
        {
            return;
        }
    }
    public void Clik_P(int x, int y)
    {
        Actions actions = new Actions(driver);
        actions
            .MoveByOffset(x, y)
            .Click()
            .Build()
            .Perform();
    }
    public void goToURL(string url)
    {
        driver.Navigate().GoToUrl(url);
    }
    public void Login(string userName,string passWord)
    {
        driver.FindElement(By.Name("username")).SendKeys(userName);
        driver.FindElement(By.Name("password")).SendKeys(passWord/*+key.return*/);
        // Tìm phần tử select theo tên thuộc tính 'name'
        selectElement = driver.FindElement(By.Name("app_key"));

        // Tìm tất cả các phần tử option trong phần tử select
        options = selectElement.FindElements(By.TagName("option"));

        // Duyệt qua từng phần tử option để tìm và chọn phần tử có văn bản mong muốn
        foreach (IWebElement option in options)
        {
            if (option.Text.Trim() == "Đại học - Cao đẳng")
            {
                option.Click();
                break;
            }
        }
        driver.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]")).Click();
    }
    public void test()
    {
        int y = 1;
        for (int i = 0; i < 4; i++)
        {
            Thread.Sleep(2000);
            List<string> ThoiGian = new List<string>();
            int CountListTime = 0;
            
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector(".table.font-size-lich-thi tbody > tr"));
            var rows2 = rows;
            foreach (IWebElement row in rows2)
            {
                try
                {
                    ThoiGian.Add(row.FindElement(By.CssSelector("th.bagroud")).Text);
                }
                catch (NoSuchElementException)
                {
                }
            }
            foreach (IWebElement row in rows)
            {
                try
                {
                    string tiet = row.FindElement(By.CssSelector("td.text-center")).Text;
                    string maMonHocTenMon = row.FindElement(By.CssSelector("td.pt-4 p:nth-child(1)")).Text;
                    string phongHoc = row.FindElement(By.CssSelector("td.pt-4 span strong")).Text;

                    Functions.Gi().print($"{ThoiGian[CountListTime]}", 0, y,ConsoleColor.Green);
                    Functions.Gi().print($"{maMonHocTenMon}", 30,y, ConsoleColor.Blue);
                    Functions.Gi().print($"{tiet}", 70, y, ConsoleColor.Green);
                    Functions.Gi().print($"{phongHoc}", 90, y, ConsoleColor.Blue);

                    y++;
                    CountListTime++;
                }
                catch (NoSuchElementException)
                {
                    // Bỏ qua hàng không có các phần tử cần truy cập
                }
            }
            IWebElement rightButton = driver.FindElement(By.CssSelector(".col-md-6 .fa-chevron-right"));
            ThoiGian.Clear();
            rightButton.Click();
        }
        Console.ResetColor();
    }
    public void showMenu()
    {
        Functions.Gi().print($"[Thời gian]", 5, 0,ConsoleColor.Red);
        Functions.Gi().print($"[Mã Môn học - Tên môn]", 34, 0,ConsoleColor.Red);
        Functions.Gi().print($"[Tiết]", 69, 0, ConsoleColor.Red);
        Functions.Gi().print($"[Phòng]", 91, 0, ConsoleColor.Red);

    }
}