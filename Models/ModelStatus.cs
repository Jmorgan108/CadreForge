namespace CadreForge.Models
{
    public class ModelStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        //BuiltIn is the predifined Options in the Enum I have set as a default option, any later added ones will be false.
        public bool IsBuiltIn { get; set; }
    }
}
