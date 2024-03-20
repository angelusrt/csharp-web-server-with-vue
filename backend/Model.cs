namespace backend {
  public class Pseudonym {
      public int id { get; set; }
      public string pseudonym { get; set; }
      public ICollection<Vote> votes { get; set; }
  }

  public class Vote {
      public int id { get; set; }
      public int vote { get; set; }
      public int pseudonym_id { get; set; }
      // public Pseudonym pseudonym { get; set; }
  }

  public class PostVoteRequest {
      public int pokemon { get; set; }
      public string pseudonym { get; set; }
  }
}
