
[System.Serializable]
public class Item
{
    public string ItemName;
    public int amount;
    public int price;

    public Item(string ItemName, int amount)
    {
        this.ItemName = ItemName;
        this.amount = amount;
    }
}



