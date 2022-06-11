using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

public static class DatabaseConnection
{
    public static SqliteConnection ConnectToDB()
    {
        string databaseFileName = "./course.db";
        return new SqliteConnection($"Data Source={databaseFileName}");
    }
}

public class UserTable
{
    private SqliteConnection connection;
    public UserTable()
    {
        this.connection = DatabaseConnection.ConnectToDB();
    }

    public long Add(User user)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();
        command.CommandText = 
        @"INSERT INTO users (first_name, last_name, password)
        VALUES ($first_name, $last_name, $password);

        SELECT last_insert_rowid();";
        command.Parameters.AddWithValue("$first_name", user.firstName);
        command.Parameters.AddWithValue("$last_name", user.lastName);
        command.Parameters.AddWithValue("$password", user.Password);

        long newId = (long)command.ExecuteScalar();
        connection.Close();
        return newId;
    }

    public User GetById(int id)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();

        command.CommandText = @"SELECT * FROM users WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        User user = new User();
        if (reader.Read())
        {
            user.Id = int.Parse(reader.GetString(0));
            user.firstName = reader.GetString(1);
            user.lastName = reader.GetString(2);
            user.Password = reader.GetString(3);
        }
        reader.Close();
        connection.Close();
        return user;
    }

    public User GetByNameAndPassword(User userData)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();

        command.CommandText = 
        @"SELECT * FROM users WHERE first_name = $first_name AND last_name = $last_name AND password = $password";
        command.Parameters.AddWithValue("$first_name", userData.firstName);
        command.Parameters.AddWithValue("$last_name", userData.lastName);
        command.Parameters.AddWithValue("$password", userData.Password);

        SqliteDataReader reader = command.ExecuteReader();

        User user = new User();
        if (reader.Read())
        {
            user.Id = int.Parse(reader.GetString(0));
            user.firstName = reader.GetString(1);
            user.lastName = reader.GetString(2);
            user.Password = reader.GetString(3);
        }
        reader.Close();
        connection.Close();
        return user;
    }
}

public class FlatTable
{
    List<Flat> flats = new List<Flat>();
    private SqliteConnection connection;
    public FlatTable()
    {
        this.connection = DatabaseConnection.ConnectToDB();
    }


    public long Add(Flat flat)
    {
        connection.Open();
        SqliteCommand command = this.connection.CreateCommand();
        command.CommandText = 
        @"INSERT INTO flats (flat_number, house_number, quantity_of_rooms, readiness_percentage, interior_type, walls_design, floor_design, furniture)
        VALUES ($flat_number, $house_number, $quantity_of_rooms, $readiness_percentage, $interior_type, $walls_design, $floor_design, $furniture);

        SELECT last_insert_rowid();";
        command.Parameters.AddWithValue("$flat_number", flat.flatNumber);
        command.Parameters.AddWithValue("$house_number", flat.houseNumber);
        command.Parameters.AddWithValue("$quantity_of_rooms", flat.quantityOfRooms);
        command.Parameters.AddWithValue("$readiness_percentage", flat.readinessPercentage);
        command.Parameters.AddWithValue("$interior_type", flat.interiorType);
        command.Parameters.AddWithValue("$walls_design", flat.wallsDesign);
        command.Parameters.AddWithValue("$floor_design", flat.floorDesign);
        command.Parameters.AddWithValue("$furniture", flat.furniture);

        long newId = (long)command.ExecuteScalar();
        connection.Close();
        return newId;
    }

    public void Update(Flat flat)
    {
        this.connection.Open();
        SqliteCommand command = this.connection.CreateCommand();
        command.CommandText = 
        @"UPDATE flats 
        SET flat_number = $flat_number, 
            house_number = $house_number, 
            quantity_of_rooms = $quantity_of_rooms,
            readiness_percentage = $readiness_percentage,
            interior_type = $interior_type,
            walls_design = $walls_design,
            floor_design = $floor_design,
            furniture = $furniture
        WHERE id = $id
        ";

        command.Parameters.AddWithValue("$id", flat.Id);
        command.Parameters.AddWithValue("$flat_number", flat.flatNumber);
        command.Parameters.AddWithValue("$house_number", flat.houseNumber);
        command.Parameters.AddWithValue("$quantity_of_rooms", flat.quantityOfRooms);
        command.Parameters.AddWithValue("$readiness_percentage", flat.readinessPercentage);
        command.Parameters.AddWithValue("$interior_type", flat.interiorType);
        command.Parameters.AddWithValue("$walls_design", flat.wallsDesign);
        command.Parameters.AddWithValue("$floor_design", flat.floorDesign);
        command.Parameters.AddWithValue("$furniture", flat.furniture);

        int nChanged = command.ExecuteNonQuery();

        this.connection.Close();
    }

    public Flat GetById(int id)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();

        command.CommandText = @"SELECT * FROM flats WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        Flat flat = new Flat();
        if (reader.Read())
        {
            flat.Id = int.Parse(reader.GetString(0));
            flat.flatNumber = int.Parse(reader.GetString(1));
            flat.houseNumber = int.Parse(reader.GetString(2));
            flat.quantityOfRooms = int.Parse(reader.GetString(3));
            flat.readinessPercentage = int.Parse(reader.GetString(4));
            flat.interiorType = reader.GetString(5);
            flat.wallsDesign = reader.GetString(6);
            flat.floorDesign = reader.GetString(7);
            flat.furniture = reader.GetString(8);
        }
        reader.Close();
        connection.Close();
        return flat;
    }
    
    public Flat GetByNumberHouseAndRooms(Flat flatData)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();

        command.CommandText = @"SELECT * FROM flats WHERE flat_number = $flat_number AND house_number = $house_number AND quantity_of_rooms = $quantity_of_rooms";
        command.Parameters.AddWithValue("$flat_number", flatData.flatNumber);
        command.Parameters.AddWithValue("$house_number", flatData.houseNumber);
        command.Parameters.AddWithValue("$quantity_of_rooms", flatData.quantityOfRooms);

        SqliteDataReader reader = command.ExecuteReader();

        Flat flat = new Flat();
        if (reader.Read())
        {
            flat.Id = int.Parse(reader.GetString(0));
            flat.flatNumber = int.Parse(reader.GetString(1));
            flat.houseNumber = int.Parse(reader.GetString(2));
            flat.quantityOfRooms = int.Parse(reader.GetString(3));
            flat.readinessPercentage = int.Parse(reader.GetString(4));
            flat.interiorType = reader.GetString(5);
            flat.wallsDesign = reader.GetString(6);
            flat.floorDesign = reader.GetString(7);
            flat.furniture = reader.GetString(8);
        }
        reader.Close();
        connection.Close();
        return flat;
    }
}

public class UserFlatTable
{
    List<UserFlat> userFlats = new List<UserFlat>();
    Flat flat = new Flat();
    private SqliteConnection connection;
    public UserFlatTable()
    {
        this.connection = DatabaseConnection.ConnectToDB();
    }

    public void Add(int userId, int flatId)
    {
        connection.Open();
        SqliteCommand command = this.connection.CreateCommand();
        command.CommandText = 
        @"INSERT INTO users_flats (user_id, flat_id)
        VALUES ($user_id, $flat_id);

        SELECT last_insert_rowid();";

        command.Parameters.AddWithValue("$user_id", userId);
        command.Parameters.AddWithValue("$flat_id", flatId);

        long newId = (long)command.ExecuteScalar();
        connection.Close();
    }

    public Flat GetFlatByUserId(int userId)
    {
        connection.Open();

        SqliteCommand command = this.connection.CreateCommand();

        command.CommandText = 
        @"SELECT flats.id, flats.flat_number, flats.house_number, flats.quantity_of_rooms, 
        flats.readiness_percentage, flats.interior_type, flats.walls_design, flats.floor_design, 
        flats.furniture FROM users_flats, flats 
        WHERE users_flats.user_id = $user_id AND flats.id = users_flats.flat_id";

        command.Parameters.AddWithValue("$user_id", userId);

        SqliteDataReader reader = command.ExecuteReader();
        this.userFlats = new List<UserFlat>();

        if (reader.Read())
        {
            flat.Id = int.Parse(reader.GetString(0));;
            flat.flatNumber = int.Parse(reader.GetString(1));;
            flat.houseNumber = int.Parse(reader.GetString(2));;
            flat.quantityOfRooms = int.Parse(reader.GetString(3));;
            flat.readinessPercentage = int.Parse(reader.GetString(4));;
            flat.interiorType = reader.GetString(5);
            flat.wallsDesign = reader.GetString(6);
            flat.floorDesign = reader.GetString(7);
            flat.furniture = reader.GetString(8);
        }
        reader.Close();
        connection.Close();
        return flat;
    }
}

