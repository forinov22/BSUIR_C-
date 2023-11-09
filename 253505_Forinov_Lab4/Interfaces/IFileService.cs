namespace _253505_Forinov_Lab4.Interfaces;

interface IFileService<T>
{
    IEnumerable<T> ReadFile(string fileName);
    void SaveData(IEnumerable<T> data, string fileName);
}
