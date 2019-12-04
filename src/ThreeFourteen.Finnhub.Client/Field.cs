namespace ThreeFourteen.Finnhub.Client
{
    public class Field
    {
        public Field(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}
