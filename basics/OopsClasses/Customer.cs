public class Customer
{
    //Data Member
    //Auto-implemented property
    public int Id{
        get;
        private set;
    }

    //Backing field
    private string name;
    //Property
    public string Name {
        //Internally generate a get method
        get {
            return name;
        }
        //Internally generate a set method
        set {
            if(value.Length > 0)
                name = value;
            else
                throw new Exception("Name cannot be empty");
        }
    }
    public string ContactNumber {get; set;}

    //Constructor this will be called when an object is created
    //constuctor() - Js
    public Customer()
    {
      Id = new Random().Next(1, 1000);
    }
    

/*
    public void SetName(string name)
    {
        if(name.Length > 0)
          Name = name;
        else
          throw new Exception("Name cannot be empty");
    }

    public string GetName()
    {
        return Name;
    }*/
}

public enum FuelType {
    Petrol,
    Diesel
}

public class Car{
    public string Name {get; set;}
    public string Model {get; set;}
    public FuelType Type {get; set;}
    public int Price {get; set;}
}

public enum EnquiryStatus {
    Pending,
    FollowUp,
    Purchased,
    Rejected
}

public class Enquiry {
    public Customer CustomerDetails {get; set;}
    public Car CarDetails {get; set;}

    //PRoperties which contains only a get accessor is called a read-only property
    public DateTime Date {
        get {
            return DateTime.Now;
        }
    }
    public EnquiryStatus Status {get; set;}
    public string Remarks {get; set;}
}

