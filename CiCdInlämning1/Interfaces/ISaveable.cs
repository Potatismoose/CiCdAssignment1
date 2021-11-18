namespace CiCdInlämning1.Interfaces
{
    public interface ISaveable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
    }
}
