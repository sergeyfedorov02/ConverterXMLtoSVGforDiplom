namespace SvgConverter
{
    internal class DefaultConvertOptions : ISvgConvertOptions
    {
        public bool AddTitles => false;
        public string GetTitleForObject(long objectId) => null;
    }
}