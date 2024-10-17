namespace SV21T1020533.DataLayers
{
    public interface ISimpleSelectDAL<T> where T : class
    {
        List<T> List(); 
    }
}
