using System;

public abstract class LegalDocument
{
    public string Title { get; set; }
    public string Content { get; set; }

    public LegalDocument(string title, string content)
    {
        Title = title;
        Content = content;
    }

    // Prototype method
    public abstract LegalDocument Clone();

    public virtual void Customize(string clientName, DateTime date)
    {
        Content = Content.Replace("{ClientName}", clientName)
                         .Replace("{Date}", date.ToShortDateString());
    }

    public virtual void Display()
    {
        Console.WriteLine($"--- {Title} ---");
        Console.WriteLine(Content);
        Console.WriteLine();
    }
}

public class NDADocument : LegalDocument
{
    public NDADocument(string title, string content) : base(title, content) { }

    public override LegalDocument Clone()
    {
        return new NDADocument(Title, string.Copy(Content));
    }
}

public class ContractDocument : LegalDocument
{
    public ContractDocument(string title, string content) : base(title, content) { }

    public override LegalDocument Clone()
    {
        return new ContractDocument(Title, string.Copy(Content));
    }
}

class Program
{
    static void Main1()
    {
        // Create prototype NDA
        LegalDocument ndaTemplate = new NDADocument(
            "Non-Disclosure Agreement",
            "This NDA is made between {ClientName} and LegalCorp on {Date}.\nAll shared information is confidential."
        );

        // Clone and customize for Client A
        LegalDocument clientNDA = ndaTemplate.Clone();
        clientNDA.Customize("Client A", DateTime.Now);

        // Clone and customize for Client B
        LegalDocument clientNDA2 = ndaTemplate.Clone();
        clientNDA2.Customize("Client B", DateTime.Now.AddDays(1));

        // Display documents
        ndaTemplate.Display();     // Template remains unchanged
        clientNDA.Display();       // Customized for Client A
        clientNDA2.Display();      // Customized for Client B
    }
}
