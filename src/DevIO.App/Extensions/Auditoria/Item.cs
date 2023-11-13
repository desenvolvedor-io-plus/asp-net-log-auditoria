namespace DevIO.App.Extensions.Auditoria
{

    public partial class AuditoriaHelper
    {
        public class Item
        {
            public Item(string key, string value)
            {
                Key = key;
                Value = value;
            }

            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
