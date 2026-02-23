public static class UserSession
{
    public static int UserId { get; set; }
    public static string Imie { get; set; }
    public static string Nazwisko { get; set; }
    public static decimal Portfel { get; set; }
    public static bool IsLoggedIn => UserId > 0;
}