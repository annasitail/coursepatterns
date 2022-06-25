public class User
{
    private int id;
    public int Id { get { return id; } set { if (value > 0) { id = value; } } }
    public string firstName;
    public string lastName;
    public int phoneNumber;
    public string Password { get; set; }
    public bool isInTheDatabase = false;

    public User() { }

    public User(int id, string firstName, string lastName, int phoneNumber, string password)
    {
        this.Id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.Password = password;
    }

    public override string ToString()
    {
        return $"[{this.Id}] - {this.firstName} {this.lastName}";
    }
}

public class Flat
{
    private int id;
    public int Id { get { return id; } set { if (value > 0) { id = value; } } }
    public int flatNumber;
    public int houseNumber;
    public int quantityOfRooms;
    public int readinessPercentage;
    public string interiorType;
    public string floorDesign;
    public string wallsDesign;
    public string furniture;
    public bool isInTheDatabase = false;

    public Flat() { }

    public Flat(int id, int flatNumber, int houseNumber, int quantityOfRooms, int readinessPercentage, string interiorType, string wallsDesign, string floorDesign, string furniture)
    {
        this.Id = id;
        this.flatNumber = flatNumber;
        this.houseNumber = houseNumber;
        this.quantityOfRooms = quantityOfRooms;
        this.readinessPercentage = readinessPercentage;
        this.interiorType = interiorType;
        this.wallsDesign = wallsDesign;
        this.floorDesign = floorDesign;
        this.furniture = furniture;
    }

    public override string ToString()
    {
        return $"Flat №{this.flatNumber}: {this.readinessPercentage}% of readiness\nHouse: {this.houseNumber}\nRooms: {this.quantityOfRooms}\nInterior type: {this.interiorType}\nWalls design: {this.wallsDesign}\nFloor design: {this.floorDesign}\nFurniture manufacturer: {this.furniture}";
    }
}

public class UserFlat
{
    public int id;
    public int Id { get { return id; } set { if (value > 0) { id = value; } } }
    public int userId;
    public int flatId;

    public UserFlat() { }

    public UserFlat(int id, int userId, int flatId)
    {
        this.Id = id;
        this.userId = userId;
        this.flatId = flatId;
    }
}
