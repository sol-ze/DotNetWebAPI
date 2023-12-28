namespace UsersAPI.Models {
    public record User {
        public Guid Id {get; init;}

        public String Name {get;set;}

        public String Email {get;set;}

        public int IsVerified {get; set;}

        public DateTimeOffset CreationDate{get; init;}
    }
}