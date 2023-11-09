namespace _253505_Forinov_Lab6.Interfaces;

public interface IFileService<T> where T:class
{
    IEnumerable<T> ReadFile(string fileName);
    void SaveData(IEnumerable<T> data, string fileName);
}
