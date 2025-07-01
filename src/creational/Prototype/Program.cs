namespace Prototype;

class Program
{
    static void Main()
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
