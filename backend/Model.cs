namespace backend {
  public enum VoteEnum : int {
      squirtle = 1, charmander = 2, bulbasaur = 3 
  }

  public class Pseudonym {
      public int id { get; set; }
      public string pseudonym { get; set; }
  }

  public class Vote {
      public int id { get; set; }
      public int vote { get; set; }
      public int pseudonym_id { get; set; }
  }

  public class PostVoteRequest {
      public int pokemon { get; set; }
      public string pseudonym { get; set; }
  }
}
