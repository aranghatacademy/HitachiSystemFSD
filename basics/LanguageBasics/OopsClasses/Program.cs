public class Program {
    public static void Main(string[] args) {

        Enquiry [] enquires = new Enquiry[10];
 
        string choice = "";
        var creta = new Car();
        creta.Name = "Hyundai";
        creta.Model = "Creta";
        creta.Type = FuelType.Diesel;
        creta.Price = 1400000;

        int index = 0;
        do{
            Console.WriteLine("Enter the customer name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the contact number : ");
            string contactNumber = Console.ReadLine();

            var c = new Customer();
            c.Name = name;
            c.ContactNumber = contactNumber;

            var enquiry = new Enquiry();
            enquiry.CustomerDetails = c;
            enquiry.CarDetails = creta;
            enquiry.Status = EnquiryStatus.Pending;

            enquires[index] = enquiry;
            index++;

            Console.WriteLine("Do you want to continue (Y/N) : ");
            choice = Console.ReadLine();
        }
        while(choice != "N");

        foreach(var e in enquires){
            if(e != null){
                Console.WriteLine(e.CustomerDetails.Name + " " + e.CustomerDetails.Id + " is interested in buying " + e.CarDetails.Name + " " + e.CarDetails.Model);
            }
        }
   
    }
}