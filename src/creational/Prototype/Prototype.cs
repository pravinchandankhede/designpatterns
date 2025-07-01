namespace Prototype;

using System;

public abstract class LegalDocument
{
    public String Title { get; set; }
    public String Content { get; set; }

    public LegalDocument(String title, String content)
    {
        Title = title;
        Content = content;
    }

    // Prototype method
    public abstract LegalDocument Clone();

    public virtual void Customize(String clientName, DateTime date)
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
    public NDADocument(String title, String content) : base(title, content) { }

    public override LegalDocument Clone()
    {
        // Use the constructor directly to create a new instance with the same Title and Content
        return new NDADocument(Title, new String(Content.ToCharArray()));
    }
}

public class ContractDocument : LegalDocument
{
    public ContractDocument(String title, String content) : base(title, content) { }

    public override LegalDocument Clone()
    {
        return new ContractDocument(Title, new String(Content.ToCharArray()));
    }
}
