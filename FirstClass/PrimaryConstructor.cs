namespace FirstClass
{
    // Antes utilizabamos el constructor asi:

    //public class PrimaryConstructor
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; private set; }
    //
    //    public PrimaryConstructor(int id, string name, string description)
    //    {
    //        Id = id;
    //        Name = name;
    //        Description = description;
    //    }
    //}

    // Ahora en C#12 se lo puede hacer asi:
    public class PrimaryConstructor(int id, string name, string description)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
    }
}
