class Store
{
  public string Name { get; set; }
  public int Quantity { get; set; }
  public decimal UnitPrice { get; set; }
  public decimal TotalPrice { get; set; }
  
  static void Main(string[] args)
  {
    var store = new Store();
    {
      new Store{Name = "Apple", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Bread", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Milk", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Pasta", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Rice", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Juice", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Cake", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
      new Store{Name = "Banana", Quantity = 1, UnitPrice = 1.00M, TotalPrice = 1.00M };
    }
    
    
  }
}