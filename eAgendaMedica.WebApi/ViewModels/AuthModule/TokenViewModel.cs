namespace eAgendaMedica.WebApi.ViewModels.AuthModule
{
    public class TokenViewModel
    {
        public string Key { get; set; }

        public DateTime ExpirationDate { get; set; }

        public UserTokenViewModel User { get; set; }
    }
}
