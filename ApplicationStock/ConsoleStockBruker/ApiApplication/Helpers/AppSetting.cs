namespace ApiApplication.Helpers
{
    public class AppSetting
    {
        public string Secret { get; set; }
        public AppSetting()
        {
            Secret = "1234567890 a very long word"; //TODO : utiliser le fichier appsettings ? 
        }
    }
}
