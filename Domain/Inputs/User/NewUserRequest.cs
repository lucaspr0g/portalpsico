namespace Domain.Inputs.User
{
    public class NewUserRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string State { get; set; }

        public string Email { get; set; }
    }
}