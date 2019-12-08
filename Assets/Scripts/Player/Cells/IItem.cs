public interface IItem
{
    void ChangeName(string itemName);
    void ChangeAmount(int amount);
    void ChangeReference(string itemName, int amout);
}
